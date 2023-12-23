namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Specify the path to the new image file
                string imagePath = @"C:\imagestartchange\Image.jpg"; // Change this to the actual path

                // Check if the file exists
                if (!File.Exists(imagePath))
                {
                    MessageBox.Show("Image file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Set the registry key for the startup image
                SetStartupImage(imagePath);

                MessageBox.Show("Startup image changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to set the startup image using registry
        private void SetStartupImage(string imagePath)
        {
            const string registryKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation";

            // Create or open the registry key
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(registryKeyPath, true))
            {
                if (key != null)
                {
                    // Set the OEMBackground value to 1 to enable custom startup image
                    key.SetValue("OEMBackground", 1, Microsoft.Win32.RegistryValueKind.DWord);

                    // Set the OEMLogo value to the path of the image file
                    key.SetValue("OEMLogo", imagePath, Microsoft.Win32.RegistryValueKind.String);
                }
    }
}
