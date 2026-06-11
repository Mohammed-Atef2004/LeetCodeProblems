using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeProblems.RecursionAndBinaryTreeProblems
{
    public partial class IsSubtree
    {
       
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
           if(root == null||subRoot==null) return false;
           if(IsSameTree(root,subRoot)) return true;
           return IsSubtree(root.right,subRoot)||IsSubtree(root.left,subRoot);
           
        }
    }
}
