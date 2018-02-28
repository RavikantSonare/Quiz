using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAdmin
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var wall = new List<IList<int>>();
            var result = LeastBricksDictionary(wall); // int.MaxValue
        }

        public int LeastBricksDictionary(IList<IList<int>> wall)
        {
            var edgesPerColumn = new Dictionary<int, int>();
            var maxEdgesPerColumn = 0;
            // In the UK at least, a layer of bricks is called a course.
            foreach (var course in wall)
            {
                var columnIndex = 0; int current = 0;
                for (var i = 0; i < course.Count - 1; i++)
                {
                    columnIndex += course[i];
                    edgesPerColumn.TryGetValue(columnIndex, out current);
                    edgesPerColumn[columnIndex] = ++current;
                    if (current > maxEdgesPerColumn)
                    {
                        maxEdgesPerColumn = current;
                    }
                }
            }
            return wall.Count - maxEdgesPerColumn;
        }
    }
}