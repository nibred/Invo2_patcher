namespace Invo2_patcher;

public partial class MainForm : Form
{
    private readonly string _suffix = "_patched.dll";
    private readonly string _errorMessage = "Error applying patch to file!";
    private readonly string _successMessage = "Patched successfully!";
    private readonly string _emptyOutputMessage = "Output file name is empty!";
    private string _sourceFilePath;
    public MainForm() => InitializeComponent();

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
        _sourceFilePath = openFile.FileName;
        tbSourceFileFullPath.Text = _sourceFilePath;
        tbOutputFilename.Text = Path.GetFileNameWithoutExtension(_sourceFilePath) + _suffix;
        buttonPatch.Enabled = true;
    }

    private void buttonPatch_Click(object sender, EventArgs e)
    {
        string outputFilename = tbOutputFilename.Text.Trim();

        if (string.IsNullOrWhiteSpace(outputFilename))
        {
            MessageBox.Show(_emptyOutputMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (!outputFilename.Contains(_suffix))
        {
            outputFilename += _suffix;
        }

        InvoPatcher patcher = new(_sourceFilePath, outputFilename);

        bool isPatched = patcher.Patch();
        _ = isPatched
            ? MessageBox.Show(_successMessage, "Patched", MessageBoxButtons.OK, MessageBoxIcon.Information)
            : MessageBox.Show(_errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        ResetSettings();
    }

    private void ResetSettings()
    {
        buttonPatch.Enabled = false;
        tbSourceFileFullPath.Text = string.Empty;
        tbOutputFilename.Text = string.Empty;
    }
}