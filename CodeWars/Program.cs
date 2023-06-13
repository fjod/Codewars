using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Schema;

namespace CodeWars
{
    class Program
    {
        public class Solution
        {
            public bool IsPowerOfThree(int n) {
                if(n<=0)
                    return false;
                if(n==1)
                    return true;
                return n%3==0 && IsPowerOfThree(n/3);
            }

            static void Main(string[] args)
            {
            }
        }

    }
}