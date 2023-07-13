namespace Invo2_patcher
{
    public partial class MainForm : Form
    {
        private readonly string _suffix = "_patched.dll";
        private readonly string _errorMessage = "File not patched!";
        private readonly string _successMessage = "Patched successfully!";
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFile = new()
            {
                Multiselect = false,
                Title = "Select file",
                Filter = "DLL Files(*.dll) | *.dll"
            };
            if (openFile.ShowDialog() != DialogResult.OK)
            {
                ResetSettings();
                return;
            }
            tbSourceFileFullPath.Text = openFile.FileName;
            tbOutputFilename.Text = Path.GetFileNameWithoutExtension(openFile.FileName) + _suffix;
            buttonPatch.Enabled = true;
        }

        private void buttonPatch_Click(object sender, EventArgs e)
        {
            var patcher = new InvoPatcher(tbSourceFileFullPath.Text, tbOutputFilename.Text);
            if (patcher.Patch())
                MessageBox.Show(_successMessage, "Patched", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(_errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ResetSettings();
        }

        private void ResetSettings()
        {
            buttonPatch.Enabled = false;
            tbSourceFileFullPath.Text = string.Empty;
            tbOutputFilename.Text = string.Empty;
        }
    }
}