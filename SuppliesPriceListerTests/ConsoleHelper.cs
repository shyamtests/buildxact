using System;
using System.IO;

namespace SuppliesPriceListerTests
{
    public class ConsoleOutput : IDisposable
        {
            private StringWriter stringWriter;
            private readonly TextWriter _originalOutput;

            public ConsoleOutput()
            {
                stringWriter = new StringWriter();
                _originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public string GetOuput()
            {
                return stringWriter.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(_originalOutput);
                stringWriter.Dispose();
            }
        }
    
    
}
