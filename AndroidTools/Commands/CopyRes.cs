using ManyConsole;
using NDesk.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidTools.Commands
{
    class CopyRes : ConsoleCommand
    {
        private bool _force;
        private String _srcResPath;
        private String _dstResPath;
        private String _resName;

        public CopyRes()
        {
            this.IsCommand("copyres", "Find and copy all versions of a resourse from one res folder to another.");

            HasOption("f|force", "Overwrite destination file if exists", b => _force = true);
            HasRequiredOption("s|source=", "Source res path", v => _srcResPath = v);
            HasRequiredOption("d|destination=", "Destination res path", v => _dstResPath = v);
            HasRequiredOption("r|res=", "res name (with extension)", v => _resName = v);
        }


        public override int Run(string[] remainingArguments)
        {
            try
            {
                int cmpt = 0;
                foreach (var dir in Directory.GetDirectories(_srcResPath))
                {
                    String src = Path.Combine(dir, _resName);
                    if(!File.Exists(src))
                        continue;
                    String subDir = dir.Split(new[]{Path.DirectorySeparatorChar,Path.AltDirectorySeparatorChar}, StringSplitOptions.RemoveEmptyEntries).Last();
                    String dstDir = Path.Combine(_dstResPath, subDir);
                    if (!Directory.Exists(dstDir))
                    {
                        Directory.CreateDirectory(dstDir);
                        Console.WriteLine("Dir created: {0}", subDir);
                    }

                    String dst = Path.Combine(dstDir, _resName);
                    bool exists = File.Exists(dst);
                    File.Copy(src, dst, _force);
                    Console.WriteLine(exists ? "Overwrited: {0}" : "Copied: {0}", Path.Combine(subDir, _resName));
                    cmpt++;
                }
                if (cmpt < 1)
                    throw new Exception("Resource not found in source res");
                Console.WriteLine("{0} file{1} copied", cmpt, cmpt > 1 ? "s" : "");
                return 0;
            }
            catch (Exception e)
            {
                Console.Error.Write("Error: {0}", e.Message);
                return 1;
            }
        }
    }
}
