using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        #region Define some structure
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        #endregion

        #region Solution 1-100
        /// <summary>
        /// 1. Two Sum
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            int a = 0;
            int b = 0;

            foreach (int i in nums)
            {
                bool flag = false;
                b = 0;
                foreach (int j in nums)
                {
                    if (a == b)
                    {
                        b++; continue;
                    }
                    if (i + j == target)
                    {
                        flag = true;
                        break;
                    }
                    b++;
                }
                if (flag == true) break;
                a++;
            }

            int[] ret = { a, b };
            return ret;
        }

        /// <summary>
        /// 2. Add Two Numbers
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var ret = Add(l1, l2);

            return ret;
        }

        private ListNode Add(ListNode l1, ListNode l2, int carry = 0)
        {
            if (l1 == null && l2 == null)
            {
                if (carry != 0)
                {
                    return new ListNode(1);
                }
                return null;
            }

            ListNode ret;
            var val = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;

            if (val >= 10)
            {
                ret = new ListNode(val - 10);
                ret.next = Add(l1?.next, l2?.next, 1);
            }
            else
            {
                ret = new ListNode(val);
                ret.next = Add(l1?.next, l2?.next);
            }

            return ret;
        }

        /// <summary>
        /// 3. Longest Substring Without Repeating Characters
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            int max = 0;
            for (int j = 0; j < s.Length; j++)
            {
                int now = 0;
                var dic = new HashSet<char>();
                while (now + j < s.Length)
                {
                    var flag = dic.Add(s[now + j]);
                    if (flag) now++;
                    else break;
                }
                if (now > max) max = now;
            }
            return max;
        }

        /// <summary>
        /// 4. Median of Two Sorted Arrays
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if(nums1.Length == 0)
            {
                if((nums2.Length % 2) != 0)
                {
                    return (double)nums2[(nums2.Length / 2) ];
                }
                else
                {
                    int c = nums2.Length / 2;
                    return ((double)nums2[c - 1] + (double)nums2[c]) / 2d;
                }
            }
            if (nums2.Length == 0)
            {
                if ((nums1.Length % 2) != 0)
                {
                    return (double)nums1[(nums1.Length / 2)];
                }
                else
                {
                    int c = nums1.Length / 2;
                    return ((double)nums1[c - 1] + (double)nums1[c]) / 2d;
                }
            }

            var list1 = nums1.ToList();
            var list2 = nums2.ToList();
            var list = new List<int>();
            list.AddRange(list1);
            list.AddRange(list2);
            list = list.OrderBy(o => o).ToList();
            if((list.Count % 2) != 0)
            {
                int c = (list.Count / 2);
                return (double)list[c];
            }
            else
            {
                int c = list.Count / 2;
                return (((double)list[c - 1] + (double)list[c]) / 2d);
            }
        }

        /// <summary>
        /// 21. Merge Two Sorted Lists
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {

            ListNode ret;
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }

            ret = l1.val < l2.val ? l1 : l2;

            ret.next = MergeTwoLists(ret == l1 ? l2 : l1, ret == l1 ? l1.next : l2.next);

            return ret;
        }

        /// <summary>
        /// 26. Remove Duplicates from Sorted Array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            int last = 0;
            int next = 1;

            if (nums.Length == 0 || nums.Length == 1)
            {
                return nums.Length;
            }

            while (next < nums.Length)
            {
                if (nums[last] == nums[next])
                {
                    next++;
                }
                else
                {
                    last++;
                    nums[last] = nums[next];
                }
            }
            return last + 1;

        }

        /// <summary>
        /// 27. Remove Element
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        {
            int retIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[retIndex] = nums[i];
                    retIndex++;
                }
            }

            return retIndex;
        }

        /// <summary>
        /// 28. Implement strStr()
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {

            int index = -1;
            int hlen = haystack.Length;
            int nlen = needle.Length;

            if (nlen == 0)
            {
                return 0;
            }
            for (int i = 0; i < hlen; i++)
            {
                if (haystack[i] == needle[0])
                {
                    if (hlen - i < nlen)
                    {
                        return index;
                    }

                    for (int j = 0; j < nlen; j++)
                    {
                        if (haystack[i + j] != needle[j])
                        {
                            break;
                        }
                        else if (j == nlen - 1)
                        {
                            return i;
                        }
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// 35. Search Insert Position
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            var len = nums.Length;

            if (nums[0] >= target)
            {
                return 0;
            }
            else if (nums[len - 1] < target)
            {
                return len;
            }

            if (nums[(int)len / 2] > target)
            {
                for (int i = (int)len / 2; i >= 0; i--)
                {
                    if (nums[i] < target)
                    {
                        return i + 1;
                    }
                    if (nums[i] == target)
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (int i = (int)len / 2; i < len; i++)
                {
                    if (nums[i] >= target)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 38. Count and Say
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }

            var str = new StringBuilder();

            string ret = "1";


            for (int i = 2; i <= n; i++)
            {
                var count = 0;
                char now = ret[0];
                for (int j = 0; j < ret.Length; j++)
                {
                    if (now == ret[j])
                    {
                        count++;
                    }
                    else
                    {
                        str = str.Append(count.ToString()).Append(now);
                        now = ret[j];
                        count = 1;
                    }
                }
                ret = str.Append(count.ToString()).Append(now).ToString();
                str.Length = 0;
            }

            return ret;
        }
        #endregion

        #region Solution 101-200
        /// <summary>
        /// 104. Maximum Depth of Binary Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {

            if (root == null) return 0;

            if (root.right == null && root.left == null) return 1;

            var left = 1;
            var right = 1;
            if (root.left != null)
                left += MaxDepth(root.left);

            if (root.right != null)
                right += MaxDepth(root.right);

            return left > right ? left : right;
        }

        /// <summary>
        /// 136. Single Number
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {

            HashSet<int> set = new HashSet<int>();

            var rets = new HashSet<int>(nums.ToList());

            List<int> list = new List<int>();

            foreach (int num in nums)
            {
                var ret = set.Add(num);

                if (!ret)
                {
                    rets.Remove(num);
                }
            }

            return rets.Single();
        }
        #endregion

        #region Solution 201-300

        /// <summary>
        /// 283. Move Zeroes
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {

            var count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    count++;

                if (count != 0 && nums[i] != 0)
                {
                    nums[i - count] = nums[i];

                    nums[i] = 0;
                }
            }
        }
        #endregion

        #region Solution 301-400

        /// <summary>
        /// 344. Reverse String
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseString(string s)
        {

            char[] cs = s.ToCharArray();

            int l = 0;
            int r = s.Length - 1;

            while (l < r)
            {
                char tmp = cs[l];
                cs[l] = cs[r];
                cs[r] = tmp;
                l++;
                r--;
            }
            return new string(cs);
        }
        #endregion

        #region Solution 401-500

        /// <summary>
        /// 412. Fizz Buzz
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> FizzBuzz(int n)
        {

            if (n == 0) return new List<string>();

            var ret = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                var t = i % 3;
                var f = i % 5;
                if (t == 0 && f == 0)
                {
                    ret.Add("FizzBuzz");
                }
                else if (t == 0)
                {
                    ret.Add("Fizz");
                }
                else if (f == 0)
                {
                    ret.Add("Buzz");
                }
                else
                {
                    ret.Add(i.ToString());
                }
            }
            return ret;
        }
        #endregion

        #region Solution 501-600

        #endregion

        #region Solution 601-700

        #endregion

        #region Solution 701-800

        /// <summary>
        /// 709. To Lower Case
        /// TODO
        /// This Solution is just a joke, :)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ToLowerCase(string str)
        {

            return str.ToLower();
        }

        /// <summary>
        /// 771. Jewels and Stones
        /// </summary>
        /// <param name="J"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public int NumJewelsInStones(string J, string S)
        {

            if (J.Length == 0) return 0;
            if (S.Length == 0) return 0;

            var jList = new HashSet<char>();
            var count = 0;
            foreach (char c in J)
            {
                jList.Add(c);
            }

            foreach (char s in S)
            {
                if (jList.Contains(s)) count++;
            }

            return count;
        }
        #endregion


    }
}
