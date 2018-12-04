using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem01.IEnumerableDemo
{
    public class SoftUniCollection : IEnumerable<Student>
    {
        private readonly List<Student> students;

        public SoftUniCollection(List<Student> students)
        {
            this.students = students;
        }

        public IEnumerator<Student> GetEnumerator()
        {
            for (int i = 0; i < this.students.Count; i++)
            {
                if (i % 2 != 0)
                {
                    yield break;
                }

                yield return this.students[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
