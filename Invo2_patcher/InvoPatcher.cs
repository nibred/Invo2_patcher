using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Invo2_patcher;

internal class InvoPatcher
{
    private readonly string BaseType = "INVO2.MainWindow";
    private readonly string TargetMethodName = "licenc";
    private readonly string _filepath;
    private readonly string _outputFilename;
    private AssemblyDefinition _assembly;

    public InvoPatcher(string filepath, string outputFilename)
    {
        _filepath = filepath;
        _outputFilename = outputFilename;
    }
    public bool Patch()
    {
        if (!TryGetTargetMethod(_filepath, out MethodDefinition? targetMethod))
        {
            return false;
        }

        ClearMethodBody(ref targetMethod!);

        targetMethod.Body.GetILProcessor().Body.InitLocals = true;
        targetMethod.Body.GetILProcessor().Append(Instruction.Create(OpCodes.Ldc_I4_1));
        targetMethod.Body.GetILProcessor().Append(Instruction.Create(OpCodes.Ret));

        return TryWriteFile();
    }

    private static void ClearMethodBody(ref MethodDefinition method)
    {
        method.Body.Instructions.Clear();
        method.Body.ExceptionHandlers.Clear();
        method.Body.Variables.Clear();
    }

    private bool TryGetTargetMethod(string filepath, out MethodDefinition? targetMethod)
    {
        _assembly = AssemblyDefinition.ReadAssembly(filepath);
        TypeDefinition? type = _assembly.MainModule.GetType(BaseType);
        targetMethod = type?.Methods
            .FirstOrDefault(x => x.Name.ToLower().Contains(TargetMethodName));
        return targetMethod is not null;
    }

    private bool TryWriteFile()
    {
        try
        {
            string savePath = Path.Combine(Path.GetDirectoryName(_filepath)!, _outputFilename);
            _assembly.Write(savePath);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
