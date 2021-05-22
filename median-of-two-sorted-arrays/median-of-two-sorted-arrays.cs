public class Solution {
    
    //ABSOLUTELY unreadable but it runs in O(m+n)
  public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {

            int middle = (nums1.Length + nums2.Length) / 2;

            int j = 0;

            int i = 0;

            bool nums1One = false;
            bool nums1Two = false;


            //If the length of the lists is only 1
            if (nums1.Length + nums2.Length == 1)
            {
                return nums1.Length == 1 ? nums1[0] : nums2[0];
            }

            if (nums1.Length == 0)
            {
                if (nums2.Length % 2 == 0)
                {
                    return (double)(nums2[nums2.Length / 2] + nums2[nums2.Length / 2 - 1]) / 2;
                }

                return nums2[nums2.Length / 2];

            }

            if (nums2.Length == 0)
            {
                if (nums1.Length % 2 == 0)
                {
                    return (double)(nums1[nums1.Length / 2] + nums1[nums1.Length / 2 - 1]) / 2;
                }

                return nums1[nums1.Length / 2];

            }

            while (i + j <= middle)
            {

                if (i >= nums1.Length)
                {
                    int difference = middle - i - j + 1;

                    j += difference;
                    if (difference > 1)
                    {
                        nums1One = false;
                        nums1Two = false;
                        break;
                    }

                    nums1Two = nums1One;
                    nums1One = false;
                    break;
                }

                if (j >= nums2.Length)
                {
                    int difference = middle - i - j + 1;

                    i += difference;
                    if (difference > 1)
                    {
                        nums1One = true;
                        nums1Two = true;
                        break;
                    }
                    nums1Two = nums1One;
                    nums1One = true;
                    break;
                }
                if (nums1[i] < nums2[j])
                {
                    i++;
                    nums1Two = nums1One;
                    nums1One = true;
                    continue;
                }
                nums1Two = nums1One;
                nums1One = false;

                j++;
            }

            i--;
            j--;
            if ((nums1.Length + nums2.Length) % 2 == 0)
            {
                int toReturn;
                if (nums1One)
                {
                    toReturn = nums1[i--];
                }
                else
                {
                    toReturn = nums2[j--];
                }

                return (double)(toReturn + (nums1Two ? nums1[i] : nums2[j])) / 2;
            }

            return nums1One ? nums1[i] : nums2[j];

        }
}