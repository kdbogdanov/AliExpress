using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    /// <summary>
    /// Generic class for node in Tree
    /// </summary>
    /// <typeparam name="T">Type of node</typeparam>
    public class TreeNode<T>
    {
        /// <summary>
        /// Data about node
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// A set of children of the node
        /// </summary>
        public IEnumerable<TreeNode<T>> Children { get; set; }
    }
}
