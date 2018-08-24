using System.Diagnostics;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IWrapper wrapper = new FileDetailsExtended();
            var result = wrapper.Action<string>(args[0], args[1]);
             
            Debug.WriteLine("Parameter Action: " + args[0]);
            Debug.WriteLine("Parameter Filename: " + args[1]);
            Debug.WriteLine("Action result : " + result);
        }
    }
}
