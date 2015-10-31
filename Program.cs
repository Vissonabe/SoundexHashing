using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundexHashing
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Plesse enter a string/Name");
            var name = Console.ReadLine();
            Console.WriteLine("Soundex Hashed Value is "+(p.HashName(name)));
            Console.ReadLine();

        }

        public string HashName(string name)
        {
            char[] _vowels = { 'a', 'e', 'i', 'o', 'u' };
            char[] _oneValues = { 'b', 'f', 'p', 'v' };
            char[] _twoValues = { 'c', 'g', 'j', 'k', 'q', 's', 'x', 'z' };
            char[] _threeValues = { 'd', 't' };
            char[] _fourValues = { 'l' };
            char[] _fiveValues = { 'm', 'n' };
            char[] _sixValues = { 'r' };
            char[] _removeChar = { 'h', 'w' };
 

            string _hashedNamed = "";
            
            char[] _lowercaseName = name.ToLower().ToCharArray();
            _hashedNamed += _lowercaseName[0].ToString().ToUpper();

            string _numValues = string.Empty;

            foreach (char c in _lowercaseName.Skip(1))
            {
                if(_vowels.Contains(c))
                {
                    continue;
                }
                else if(_removeChar.Contains(c))
                {
                    continue;
                }
                else if(_oneValues.Contains(c))
                {
                    _numValues += "1";
                }
                else if (_twoValues.Contains(c))
                {
                    _numValues += "2";
                }
                else if (_threeValues.Contains(c))
                {
                    _numValues += "3";
                }
                else if (_fourValues.Contains(c))
                {
                    _numValues += "4";
                }
                else if (_fiveValues.Contains(c))
                {
                    _numValues += "5";
                }
                else if (_sixValues.Contains(c))
                {
                    _numValues += "6";
                }
            }

            int Length = _numValues.Length;
            for (int i =0;i<Length; i++)
            {
                int j = i + 1;
                if(j<Length && _numValues[i].Equals(_numValues[j]))
                {
                   _numValues = _numValues.Remove(j,1);
                    Length = _numValues.Length;
                }
            }

            if(_numValues.Length > 2)
            {
                _numValues = _numValues.Remove(3);
            }
            else
            {
                while(_numValues.Length<=2)
                {
                    _numValues += "0";
                }
            }

            _hashedNamed += _numValues;

            return _hashedNamed;
        }
    }

    
}
