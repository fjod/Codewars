using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> coursesPrereqs = new Dictionary<int, List<int>>(numCourses - 1);
            HashSet<int> visited = new HashSet<int>(numCourses - 1);
            for (int i = 0; i < numCourses; i++)
            {
                var preqs = prerequisites.Where(p => p[0] == i).Select(p => p[1]).ToList();
                coursesPrereqs.Add(i, preqs);
            }

            foreach (int c in Enumerable.Range(0, numCourses))
            {
                visited.Clear();
                if (!checkCourse(c, coursesPrereqs, visited))
                {
                    return false;
                }
            }
            return true;
        }

        private static Dictionary<int, bool> canFinish = new Dictionary<int, bool>();
        private static bool checkCourse(int i, Dictionary<int, List<int>> coursesPrereqs, HashSet<int> visited)
        {
            if (visited.Contains(i)) return false;
            var prequesForTheCourse = coursesPrereqs[i];
            if (!prequesForTheCourse.Any()) return true;
            visited.Add(i);
            foreach (var i1 in prequesForTheCourse)
            {
                if (!canFinish.ContainsKey(i1))
                {
                    var course = checkCourse(i1, coursesPrereqs, visited);
                    if (!course)
                    {
                        return false;
                    }

                    canFinish.Add(i1, true);
                    visited.Remove(i1);
                }
                else return canFinish[i1];
            }

            return true;
        }


        static void Main(string[] args)
        {
            var q2 = CanFinish(8, new[]
            {
                new []{1,0},
                new []{0,1},
            });
            var q1 = CanFinish(8, new[]
            {
                new []{1,0},
                new []{2,6},
                new []{1,7},
                new []{6,4},
                new []{7,0},
                new []{0,5},
            });

            Console.ReadKey();
        }
    }


}