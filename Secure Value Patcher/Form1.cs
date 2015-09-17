using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Pokemon_Shuffle_Hack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Gameselect.Items.Insert(0, "                            -- Use Secure Value Location file --");
	       	Gameselect.Items.Insert(1, "                                       Pokemon Shuffle");
			Gameselect.Items.Insert(2, "                                         Pokemon X/Y");
			Gameselect.Items.Insert(3, "                                        Pokemon ORAS");
			Gameselect.Items.Insert(4, "                                     Pokemon ORAS Demo");
			Gameselect.Items.Insert(5, "                                    Super Smash Bros. 3DS");
			Gameselect.Items.Insert(6, "                                Super Smash Bros. 3DS Demo");
			Gameselect.Items.Insert(7, "                                   Animal Crossing New Leaf");
			Gameselect.SelectedIndex = 0;
			button2.Enabled = false;
        }


        public string savegame
        {
            get { return savegamename1.Text; }
        }
        public string savegame2
        {
            get { return savegamename2.Text; }
        }
        public string securevalue
        {
            get { return securevaluename.Text; }
        }

        private void BLKDTH_get_data_good()
        {
            OpenFileDialog openFD = new OpenFileDialog();
            //openFD.InitialDirectory = "c:\\";
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                #region filename
                savegamename2.Text = openFD.FileName;
                #endregion
            }
        }
        private void BLKDTH_get_data_corrupt()
        {
            OpenFileDialog openFD = new OpenFileDialog();
            //openFD.InitialDirectory = "c:\\";
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                #region filename
                savegamename1.Text = openFD.FileName;
                #endregion
            }
        }

        private void BLKDTH_get_data_secure()
        {
            OpenFileDialog openFD = new OpenFileDialog();
            //openFD.InitialDirectory = "c:\\";
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                #region filename
                securevaluename.Text = openFD.FileName;
                if (File.ReadLines(securevalue).First() =="0x2c")
                {
                    GameName.BackColor = Color.LightGreen; 
                    GameName.Text = "Pokemon Shuffle";
                }
                else if (File.ReadLines(securevalue).First() == "0x65400")
                {
                    GameName.BackColor = Color.LightGreen; 
                    GameName.Text = "Pokemon X/Y";
                }
                else if (File.ReadLines(securevalue).First() == "0x75E00")
                {
                    GameName.BackColor = Color.LightGreen; 
                    GameName.Text = "Pokemon ORAS";
                }
                else if (File.ReadLines(securevalue).First() == "0x5800")
                {
                    GameName.BackColor = Color.LightGreen; 
                    GameName.Text = "Pokemon ORAS Demo";
                }
				else if (File.ReadLines(securevalue).First() =="0x10")
				{
					GameName.BackColor = Color.LightGreen;
					GameName.Text = "Super Smash Bros. 3DS / Super Smash Bros. 3DS Demo";
					MessageBox.Show("Keep in mind you have to fix both [account_data.bin and system_data.bin] files", "Super Smash Bros. 3DS / Super Smash Bros. 3DS Demo");
				}
				else if (File.ReadLines(securevalue).First() == "0x00")
                {
					
                    GameName.BackColor = Color.LightGreen;
                    GameName.Text = "Animal Crossing New Leaf";
                }                
                else
                {
                    GameName.BackColor = Color.OrangeRed;
                    GameName.Text = "Unknown Offset found - use at your own risk";
                }
                #endregion
                ShowValue.Text = File.ReadLines(securevalue).First();
            }
        }

        private void BLKDTH_set_data()
        {
	        	string offset = null;
				if (Gameselect.SelectedIndex.Equals(0))
				{
					if (string.IsNullOrEmpty(securevaluename.Text))
					{
						MessageBox.Show("Please select a game or a Secure Value Location file.", "Error");
						return;
					}
	        		offset = File.ReadLines(securevalue).First();
	        	}
	        	else if (Gameselect.SelectedIndex.Equals(1))
	        	{
	        		offset = "0x2c";
				}
	        	else if (Gameselect.SelectedIndex.Equals(2))
	        	{
					offset = "0x65400";
				}
	        	else if (Gameselect.SelectedIndex.Equals(3))
	        	{
					offset = "0x75E00";
				}
	        	else if (Gameselect.SelectedIndex.Equals(4))
	        	{
					offset = "0x5800";
				}
	        	else if (Gameselect.SelectedIndex.Equals(5))
	        	{
					offset = "0x10";
				}
	        	else if (Gameselect.SelectedIndex.Equals(6))
	        	{
					offset = "0x10";
				}
	        	else if (Gameselect.SelectedIndex.Equals(7))
	        	{
					offset = "0x00";
	        	}
	        	else //should never happen
	        	{
					MessageBox.Show("Error", "Error");
					return;
	        	}
				int plusone = 0;
	        	if (Backupcheck.Checked)
	        	{
		        	//First backup the "old" file
		        	if (File.Exists(savegame+".bak"+plusone.ToString()))
			        {
						while (File.Exists(savegame+".bak"+plusone.ToString()))
						{
							plusone++;
						}
/*
							DialogResult dialogResult = MessageBox.Show("A backup of your old savegame was found, if you continue it will be overwritten with the current selected old file.\rContinue? ", "Bakcup found", MessageBoxButtons.YesNo);
							if(dialogResult == DialogResult.Yes)
							{
							}
							else if (dialogResult == DialogResult.No)
							{
								return;
			        		}
*/		
			        }
	        	
				    using (Stream source = File.OpenRead(savegame))
				    using (Stream dest = File.Create(savegame+".bak"+plusone.ToString()))
				    {
				        byte[] buffer = new byte[source.Length]; // pick size
				        int bytesRead;
				        while((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0) {
				            dest.Write(buffer, 0, bytesRead);
				        }
				        source.Close();
				        dest.Close();
				    }
	        	}

	        	//Now update old file with new secure value
	            FileStream savegame_fs = new FileStream(savegame2, FileMode.Open);
	            BinaryReader savegame_br = new BinaryReader(savegame_fs);
	            long length = savegame_fs.Length;
	            savegame_br.BaseStream.Position = Convert.ToInt64 (offset, 16);
	            byte[] goodbytes = savegame_br.ReadBytes(8);
	            System.IO.FileStream update_save_open = null;
	            System.IO.BinaryWriter update_save_write = null;
	            update_save_open = new System.IO.FileStream(savegame, System.IO.FileMode.OpenOrCreate);
	            //Check filesizes
	          	if (length.CompareTo(update_save_open.Length) != 0)
	            {
	         		DialogResult dialogResult = MessageBox.Show("Old save file and new save file have different sizes! Wrong file selected?\r\r Do you want to continue anyways?", "Size error", MessageBoxButtons.YesNo);
					if(dialogResult == DialogResult.Yes)
					{
					}
					else if (dialogResult == DialogResult.No)
					{
						update_save_open.Close();
	            		savegame_br.Close();
						return;
		    		}
	            }
	            update_save_write = new System.IO.BinaryWriter(update_save_open);
	            update_save_open.Position = Convert.ToInt64 (offset, 16);
	            update_save_write.Write(goodbytes);
	            update_save_open.Close();
	            savegame_br.Close();
	            if (Backupcheck.Checked)
	            {
	            	MessageBox.Show("Save should work now.\rOld file was backed up at "+savegame+".bak"+plusone.ToString(), "Secure Value updated");
	            }else{
	            	MessageBox.Show("Save should work now.", "Secure Value updated");
	            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLKDTH_get_data_corrupt();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BLKDTH_set_data();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BLKDTH_get_data_good();
        }
		private void Button4Click(object sender, EventArgs e)
		{
	        BLKDTH_get_data_secure();
		}
		void SecurevaluenameTextChanged(object sender, EventArgs e)
		{
	
		}
		void GameNameTextChanged(object sender, EventArgs e)
		{
	
		}
		
		void GameselectSelectedIndexChanged(object sender, EventArgs e)
		{
			if (Gameselect.SelectedIndex.Equals(0)) {
				button4.Enabled = true;
				securevaluename.Enabled = true;
				GameName.Enabled = true;
				ShowValue.Text = "";
				if(!string.IsNullOrEmpty(securevaluename.Text))ShowValue.Text = File.ReadLines(securevalue).First();
			}else{
				button4.Enabled = false;
				securevaluename.Enabled = false;
				GameName.Enabled = false;
			}
			if (Gameselect.SelectedIndex.Equals(1)) {
				ShowValue.Text = "0x2c";
			}
			if (Gameselect.SelectedIndex.Equals(2)) {
				ShowValue.Text = "0x65400";
			}
			if (Gameselect.SelectedIndex.Equals(3)) {
				ShowValue.Text = "0x75E00";
			}
			if (Gameselect.SelectedIndex.Equals(4)) {
				ShowValue.Text = "0x5800";
			}
			if (Gameselect.SelectedIndex.Equals(5)) {
				MessageBox.Show("Keep in mind you have to fix both [account_data.bin and system_data.bin] files", "Super Smash Bros. 3DS");
				ShowValue.Text = "0x10";
			}
			if (Gameselect.SelectedIndex.Equals(6)) {
				MessageBox.Show("Keep in mind you have to fix both [account_data.bin and system_data.bin] files", "Super Smash Bros. 3DS Demo");
				ShowValue.Text = "0x10";
			}
			if (Gameselect.SelectedIndex.Equals(7)) {
				ShowValue.Text = "0x00";
			}
		}
		void Savegamename1TextChanged(object sender, EventArgs e)
		{
		    if (string.IsNullOrEmpty(savegamename1.Text) || string.IsNullOrEmpty(savegamename2.Text) )
		        button2.Enabled = false;
		    else
		        button2.Enabled = true;
		}
		void Savegamename2TextChanged(object sender, EventArgs e)
		{
		    if (string.IsNullOrEmpty(savegamename1.Text) || string.IsNullOrEmpty(savegamename2.Text) )
		        button2.Enabled = false;
		    else
		        button2.Enabled = true;
		}
		void ShowValueTextChanged(object sender, EventArgs e)
		{
	
		}
		void BackupcheckCheckedChanged(object sender, EventArgs e)
		{

		}

    }
}
