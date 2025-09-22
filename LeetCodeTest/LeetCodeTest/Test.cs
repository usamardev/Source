using static System.Net.Mime.MediaTypeNames;

namespace LeetCodeTest
{
    public class Test
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            int wordCount = 0;
            List<string> wordList = new List<string>();
            List<string> resultList = new List<string>();

            foreach (string word in words)
            {
                if (word.Length + wordCount > maxWidth)
                {
                    resultList.Add(SplitIntoParts(wordList, maxWidth - (wordCount - 1)));
                    wordList = new List<string>();
                    wordList.Add(word);
                    wordCount = word.Length;
                }
                else
                {
                    wordList.Add(word);
                    wordCount += word.Length;
                }
                wordCount++;
            }
            string text = "";
            foreach (string word in wordList)
            {
                text += word + " ";
            }
            text = text.TrimEnd();
            text += new string(' ', maxWidth - text.Length);
            resultList.Add(text);

            return resultList;
        }

        public int Trap(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0, water = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] >= leftMax)
                        leftMax = height[left];
                    else
                        water += leftMax - height[left];
                    left++;
                }
                else
                {
                    if (height[right] >= rightMax)
                        rightMax = height[right];
                    else
                        water += rightMax - height[right];
                    right--;
                }
            }
            return water;
        }

        public string Convert(string s, int numRows)
        {
            if (numRows == 1 || s.Length <= numRows)
                return s;
            bool rightback = true;
            string resultString = "";
            string[] result = new string[numRows];
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                result[count] += s[i].ToString();
                if (rightback)
                {
                    count++;
                    if (count == numRows - 1)
                        rightback = false;
                }
                else
                {
                    count--;
                    if (count == 0)
                        rightback = true;
                }
            }
            for (int i = 0; i < numRows; i++)
                resultString += result[i].ToString();

            return resultString;
        }

        public string SplitIntoParts(List<string> words, int allCount)
        {
            int count = words.Count - 1;
            allCount += count;
            int spaceCount = (count == 0) ? 1 : count;
            if (spaceCount >= allCount)
                allCount = allCount + spaceCount;

            int baseValue = allCount / spaceCount;
            int remainder = allCount % spaceCount;
            string resultString = "";

            for (int i = 0; i < spaceCount; i++)
            {
                if (i < remainder)
                    resultString += words[i] + new string(' ', baseValue + 1);
                else
                    resultString += words[i] + new string(' ', baseValue);
            }

            resultString += words[count];

            return resultString;
        }

        public bool IsPalindrome(string s)
        {
            int leftCount = s.Length;
            if (leftCount == 0) return true;
            int rightCount = 0;
            leftCount--;
            s = s.ToLower();

            while (leftCount >= rightCount)
            {
                if ((s[leftCount] < 97 || s[leftCount] > 122) && (s[leftCount] < 48 || s[leftCount] > 57))
                {
                    leftCount--; continue;
                }
                if ((s[rightCount] < 97 || s[rightCount] > 122) && (s[rightCount] < 48 || s[rightCount] > 57))
                {
                    rightCount++; continue;
                }
                if (s[leftCount] == s[rightCount])
                {
                    leftCount--; rightCount++;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsSubsequence(string s, string t)
        {
            int length = s.Length;
            if (length > t.Length) return false;

            for (int i = 0; i < length; i++)
            {
                int a = t.IndexOf(s[i]);
                if (a != -1)
                {
                    t = t.Substring(a + 1);
                    if (t.Length < length - 1 - i)
                        return false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public int MaxArea(int[] height)
        {
            int Lindex = 0, Rindex = 0;

            for (int i = 0; i < height.Length - 1; i++)
            {
                if (height[i] >= height[i + 1])
                {
                    Lindex = i;
                    break;
                }
            }


            for (int i = height.Length - 1; i >= 0; i--)
            {
                if (height[i - 1] <= height[i])
                {
                    Rindex = i;
                    break;
                }
            }
            if (Rindex == Lindex)
            {
                Rindex++;
                Lindex--;
            }
            if (Rindex > Lindex)
            {
                if (height[Rindex] >= height[Lindex])
                {
                    return height[Lindex] * (Rindex - Lindex);
                }
                else
                {
                    return height[Rindex] * (Rindex - Lindex);
                }
            }
            return 0;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            int i = 0;
            int j = i + 1;
            int k = j + 1;
            int n = nums.Length;
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();

            while (i < n - 2)
            {
                if ((nums[i] + nums[j] + nums[k]) == 0)
                {
                    IList<int> list = [nums[i], nums[j], nums[k]];
                    if (!result.Any(m => m == list))
                        result.Add(list);
                }
                k++;
                if (k == n)
                {
                    j++;
                    if (j == n - 1)
                    {
                        i++;
                        j = i + 1;
                    }
                    k = j + 1;
                }
            }

            for (int m = 0; m < result.Count - 2; m++)
            {
                if (result[m] == result[m + 1])
                    result.Remove(result[m]);
            }
            return result;
        }

        public int MinSubArrayLen(int target, int[] nums)
        {
            int n = nums.Length;
            int left = 0;
            int sum = 0;
            int minLen = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                sum += nums[i];

                while (sum >= target)
                {
                    minLen = Math.Min(minLen, i - left + 1);
                    sum -= nums[left];
                    left++;
                }
            }

            return minLen == int.MaxValue ? 0 : minLen;
        }

        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0)
                return 0;
            int maxLen = 1;
            int index = 0;
            int l = 0;

            for (int i = 1; i < s.Length; i++)
            {
                l = i - 1;
                while (l >= index)
                {
                    if (s[l] == s[i])
                    {
                        index = l + 1; break;
                    }
                    l--;
                }
                maxLen = Max(maxLen, i - index + 1);
            }
            return maxLen;
        }

        //Time Limit Exceeded 265 / 268 testcases passed
        public string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length)
            {
                return "";
            }
            int minLen = int.MaxValue;
            int startindex = 0;
            int endindex = 1;
            bool result = true;
            Dictionary<char, int> countS = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!countS.ContainsKey(s[i]))
                    countS[s[i]] = 0;
                countS[s[i]]++;

                if (i >= t.Length - 1)
                {
                    result = EquelStrings(countS, t);
                    while (result)
                    {
                        if (minLen > i - startindex + 1)
                        {
                            minLen = i - startindex + 1;
                            endindex = startindex;
                        }
                        countS[s[startindex++]]--;
                        result = EquelStrings(countS, t);
                    }
                }
            }
            return minLen == int.MaxValue ? "" : new string(s.ToCharArray(), endindex, minLen);
        }

        public bool EquelStrings(Dictionary<char, int> count, string t)
        {
            Dictionary<char, int> countS = new Dictionary<char, int>(count);
            foreach (char c in t)
            {
                if (!countS.ContainsKey(c) || countS[c] == 0)
                {
                    return false;
                }
                countS[c]--;
            }

            return true;
        }

        public string MinWindowTest(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length)
            {
                return "";
            }

            int[] map = new int[128];
            int count = t.Length;
            int start = 0, end = 0, minLen = int.MaxValue, startIndex = 0;
            /// UPVOTE !
            foreach (char c in t)
            {
                map[c]++;
            }

            char[] chS = s.ToCharArray();

            while (end < chS.Length)
            {
                if (map[chS[end++]]-- > 0)
                {
                    count--;
                }

                while (count == 0)
                {
                    if (end - start < minLen)
                    {
                        startIndex = start;
                        minLen = end - start;
                    }

                    if (map[chS[start++]]++ == 0)
                    {
                        count++;
                    }
                }
            }

            return minLen == int.MaxValue ? "" : new string(chS, startIndex, minLen);
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            List<int> result = new List<int>();
            int wordLength = words[0].Length;
            int totalLength = wordLength * words.Length;

            if (s.Length < totalLength)
                return result;

            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (dic.ContainsKey(word))
                    dic[word]++;
                else
                    dic[word] = 1;
            }

            for (int i = totalLength; i <= s.Length; i++)
            {
                Dictionary<string, int> dic1 = new Dictionary<string, int>(dic); ;
               
                for (int j = 0; j < totalLength; j += wordLength)
                {
                    string t = s.Substring(i - totalLength+j, wordLength);

                    if (dic1.ContainsKey(t))
                    {
                        if (dic1[t] == 0)
                            break;
                        dic1[t]--;
                    }
                    else
                        break;
                }

                if (dic1.Values.Sum(x => x) == 0)
                    result.Add(i - totalLength);

            }
            return result;

            //IList<int> result = new List<int>();

            //if (s.Length == 0 || words.Length == 0)
            //    return result;

            //int wordLength = words[0].Length; // Length of each word in the words array
            //int totalWords = words.Length; // Total number of words in the words array
            //int substringLength = wordLength * totalWords; // Length of the concatenated substring

            //if (s.Length < substringLength)
            //    return result;

            //Dictionary<string, int> wordCount = new Dictionary<string, int>();
            //foreach (string word in words)
            //{
            //    if (wordCount.ContainsKey(word))
            //        wordCount[word]++;
            //    else
            //        wordCount[word] = 1;
            //}
            //for (int i = 0; i < wordLength; i++)
            //{
            //    Dictionary<string, int> currentWordCount = new Dictionary<string, int>();
            //    int wordsFound = 0;
            //    int left = i;

            //    for (int j = i; j <= s.Length - wordLength; j += wordLength)
            //    {
            //        string currentWord = s.Substring(j, wordLength);

            //        if (wordCount.ContainsKey(currentWord))
            //        {
            //            if (currentWordCount.ContainsKey(currentWord))
            //                currentWordCount[currentWord]++;
            //            else
            //                currentWordCount[currentWord] = 1;

            //            wordsFound++;

            //            while (currentWordCount[currentWord] > wordCount[currentWord])
            //            {
            //                string leftWord = s.Substring(left, wordLength);
            //                currentWordCount[leftWord]--;
            //                wordsFound--;
            //                left += wordLength;
            //            }

            //            if (wordsFound == totalWords)
            //            {
            //                result.Add(left);
            //                string leftWord = s.Substring(left, wordLength);
            //                currentWordCount[leftWord]--;
            //                wordsFound--;
            //                left += wordLength;
            //            }
            //        }

            //        else
            //        {
            //            currentWordCount.Clear();
            //            wordsFound = 0;
            //            left = j + wordLength;
            //        }
            //    }
            //}

            //return result;
        }

        public string ReplaceAt(string str, int index, string newStr, int length)
        {
            if (index < 0 || index + length > str.Length)
                throw new ArgumentOutOfRangeException();

            return str.Substring(0, index) + newStr + str.Substring(index + length);
        }

        public int Max(int a, int b) => (a >= b) ? a : b;
        public int Min(int a, int b) => (a >= b) ? b : a;

    }
}
