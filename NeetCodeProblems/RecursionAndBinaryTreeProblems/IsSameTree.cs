using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems.RecursionAndBinaryTreeProblems
{
    public partial class IsSubtree
    {
        
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p==null||q==null||p.val != q.val)
                return false;
            return IsSameTree(p.right, q.right) && IsSameTree(p.left, q.left);
         
        }
    }
}
