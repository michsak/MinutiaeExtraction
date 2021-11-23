using Futronic.Scanners.FS26X80;
using FutronicFingerPrint.Forms;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutronicFingerPrint
{
    public partial class MainForm : Form
    {
        private DeviceAccessor accessor = new ();
        private FingerprintDevice device;
        public MainForm()
        {
            InitializeComponent();
            //InitializeDevice();
            
            //Task.Run(() =>
            //{
            //    device.StartFingerDetection();
            //    device.SwitchLedState(false, true);

            //    device.SwitchLedState(false, false);
            //});
        }

        private void InitializeDevice()
        {
            device = accessor.AccessFingerprintDevice();
            device.SwitchLedState(false, false);

            device.FingerDetected += FingerDetected;
            device.FingerReleased += FingerReleased;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void FingerDetected(object sender, EventArgs e)
        {
            device.SwitchLedState(true, false);

            var fingerprint = device.ReadFingerprint();
            //this.scannerPicture.Image = fingerprint;
        }

        private void FingerReleased(object sender, EventArgs e)
        {
            device.SwitchLedState(false, true);
        }
       
        private void btnCapture_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new ();
            saveFile.Title = "Save Fingerprint";
            saveFile.Filter = "*.jpg|*.png";
            saveFile.DefaultExt = "jpg";
            saveFile.AddExtension = true;
            saveFile.InitialDirectory = SpecialDirectories.MyPictures;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //this.scannerPicture.Image.Save(saveFile.FileName);
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new();

            openFile.Title = "Open Fingerprint";
            openFile.Filter = "*.jpg|*.png";
            openFile.DefaultExt = "jpg";
            openFile.AddExtension = true;
            openFile.InitialDirectory = SpecialDirectories.MyPictures;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFile.FileName))
                {
                    //this.comparedPicture.Image = Image.FromFile(openFile.FileName);
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void openToolStripBtn_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripBtn_Click(object sender, EventArgs e)
        {
            UserRegistrationForm registrationForm = new();
            registrationForm.ShowDialog();
        }

        private void saveToolStripBtn_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
