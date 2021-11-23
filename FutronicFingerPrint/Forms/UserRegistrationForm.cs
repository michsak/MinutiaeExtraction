using Futronic.Infrastructure.Services;
using Futronic.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutronicFingerPrint.Forms
{
    [Serializable]
    public partial class UserRegistrationForm : Form
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public FingerPrint LeftHand { get; set; }
        [DataMember]
        public FingerPrint RightHand { get; set; }

        private IRepository<long, User> _userRepository;
        private IRepository<long, AttendanceLog> _attendanceRepository;

        public UserRegistrationForm()
        {
            InitializeComponent();
            InstantiateRepository();
        }

        public UserRegistrationForm(long userId)
        {
            InitializeComponent();
            InstantiateRepository();
            this.Id = userId;
            Task.Run(GetUser);
        }

        private void InstantiateRepository()
        {
            var userRepository = Activator.CreateInstance(typeof(IRepository<long, User>)) as IRepository<long, User>;
            var attendanceRepository = Activator.CreateInstance(typeof(IRepository<long, AttendanceLog>)) as IRepository<long, AttendanceLog>;
            _userRepository = userRepository;
            _attendanceRepository = attendanceRepository;
        }

        private void UserRegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CreateUser();
        }

        private void btnEnrollLeft_Click(object sender, EventArgs e)
        {
            FingerprintForm form = new();
            form.ShowDialog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var fingerprints = form.GetFingerPrints();
                this.LeftHand = fingerprints;
                Task.Run(CheckRegisteredLeftFingers);
            }
        }

        private void btnEnrollRight_Click(object sender, EventArgs e)
        {
            FingerprintForm form = new();
            form.ShowDialog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var fingerprints = form.GetFingerPrints();
                this.RightHand = fingerprints;
                Task.Run(CheckRegisteredRightFingers);
            }
        }

        private async Task GetUser()
        {
            User user = new();
            user = await _userRepository.Get(Id);
            if (user != null)
            {
                FirstName = user.FirstName;
                LastName = user.LastName;
                UserName = user.UserName;
                LeftHand = user.LeftHand;
                RightHand = user.RightHand;

                Task.Run(CheckRegisteredLeftFingers);
                Task.Run(CheckRegisteredRightFingers);
                GetAttendance();
            }
        }

        private void UpdateUser()
        {
             
        }

        private void GetAttendance()
        {
            IEnumerable<AttendanceLog> logs = _attendanceRepository.GetAll(x => x.UserId == Id).GetAwaiter().GetResult();
            string[] tableHeaders = typeof(AttendanceLog).GetProperties().Select(x => x.Name).ToArray();

            this.dataGridAttendance.DataSource = logs;
        }

        private void CreateUser()
        {
            User user = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                LeftHand = LeftHand,
                RightHand = RightHand
            };

            _userRepository.Insert(user);
            var result = _userRepository.SaveChanges();
            if (result.Item1)
            {
                MessageBox.Show("User created successfully!");
            }
            else
            {
                MessageBox.Show($"An error occured while creating the user\n{result.Item2}");
            }
        }

        private void CheckRegisteredLeftFingers()
        {
            this.Invoke(new MethodInvoker(delegate () {
                checkBoxLT.Checked = LeftHand.Thumb != null;
                checkBoxLI.Checked = LeftHand.IndexFinger != null;
                checkBoxLM.Checked = LeftHand.MiddleFinger != null;
                checkBoxLR.Checked = LeftHand.RingFinger != null;
                checkBoxLL.Checked = LeftHand.LittleFinger != null;
            }));
        }

        private void CheckRegisteredRightFingers()
        {
            this.Invoke(new MethodInvoker(delegate (){
                checkBoxRT.Checked = RightHand.Thumb != null;
                checkBoxRI.Checked = RightHand.IndexFinger != null;
                checkBoxRM.Checked = RightHand.MiddleFinger != null;
                checkBoxRR.Checked = RightHand.RingFinger != null;
                checkBoxRL.Checked = RightHand.LittleFinger != null;
            }));
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            this.UserName = txtUsername.Text;
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {
            this.FirstName = txtFirstname.Text;
        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {
            this.LastName = txtLastname.Text;
        }

        private void picturePassport_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new();
            openFile.Multiselect = false;
            openFile.Title = "Select Image";
            openFile.Filter = "*.jpg|*.png";
            openFile.DefaultExt = "jpg";
            openFile.AddExtension = true;
            openFile.InitialDirectory = SpecialDirectories.MyPictures;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.picturePassport.Image = Image.FromFile(openFile.FileName);
            }
        }
    }
}
