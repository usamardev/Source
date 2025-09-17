namespace LeetCodeTest
{
    public class Hashmap
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if(ransomNote.Length>magazine.Length)
                return false;

            int[] letters = new int[26];
            foreach (char c in magazine)
                letters[c - 'a']++;
            foreach (char ch in ransomNote)
            {
                letters[ch - 'a']--;
                if (letters[ch - 'a'] == -1)
                    return false;
            }
            return true;
        }
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, char> mapST = new Dictionary<char, char>();
            Dictionary<char, char> mapTS = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                char c1 = s[i];
                char c2 = t[i];

                if (mapST.ContainsKey(c1))
                {
                    if (mapST[c1] != c2) return false;
                }
                else
                {
                    mapST[c1] = c2;
                }

                if (mapTS.ContainsKey(c2))
                {
                    if (mapTS[c2] != c1) return false;
                }
                else
                {
                    mapTS[c2] = c1;
                }
            }

            return true;
        }

        public bool WordPattern(string pattern, string s)
        {
            var dict = new Dictionary<char, string>();
            var spl = s.Split(' ');

            if (pattern.Length != spl.Length)
            {
                return false;
            }

            for (var p = 0; p < pattern.Length; p++)
            {
                if (dict.ContainsKey(pattern[p]))
                {
                    if (dict[pattern[p]] != spl[p])
                    {
                        return false;
                    }
                }
                else
                {
                    if (dict.ContainsValue(spl[p]))
                    {
                        return false;
                    }
                    dict.Add(pattern[p], spl[p]);
                }
            }

            return true;
        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            int[] nums = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                nums[s[i] - 'a']++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                nums[t[i] - 'a']--;
                if (nums[t[i] - 'a']<0)
                    return false;
            }
            return true;
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();    
            if(strs.Length == 0)
                return result;
            if (strs.Length == 1)
            {
                result.Add(new List<string>() { strs[0] });
                return result;
            }
            
            for (int i = 0;i< strs.Length; i++)
            {
                List<string> list = new List<string>();
                if (strs[i] != "0")
                {
                    list.Add(strs[i]);
                    int count = i + 1;
                    while (count < strs.Length)
                    {
                        if(strs[count] != "0"&& IsAnagram(strs[i], strs[count]))
                        { 
                            list.Add(strs[count]);
                            strs[count] = "0";
                        }
                        count++;
                    }
                }
                if (list.Count != 0)
                {
                    list.Sort();
                    result.Add(list);
                }
            }
            return result;
        }

        public IList<IList<string>> GroupAnagramsOpt(string[] strs)
        {
            var dict = new Dictionary<string, List<string>>();

            foreach (var word in strs)
            {
                // Harflarni tartiblash orqali kalit yasaymiz
                var key = new string(word.OrderBy(c => c).ToArray());

                if (!dict.ContainsKey(key))
                    dict[key] = new List<string>();

                dict[key].Add(word);
            }

            // Dictionarydagi value’larni resultga o‘tkazamiz
            return dict.Values.Cast<IList<string>>().ToList();
        }

        public bool IsHappy(int n)
        {

            if (n < 10)
            {
                return n == 1 || n == 7;
            }
            int sum = 0;
            while (n > 0)
            {
                int digit = n % 10;
                sum += digit * digit;
                n /= 10;
            }
            return IsHappy(sum);
            //if (n > 1 && n <= 9)
            //    return false;
            //int sum=0; int a=0;
            //while(n>0)
            //{
            //    a = n % 10;
            //    n = n / 10;
            //    sum += a*a;
            //}
            //if(sum ==1)
            //    return true;
            //else
            //    IsHappy(sum);
            //return (sum==1);
        }

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            HashSet<int> window = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (window.Contains(nums[i]))
                {
                    return true;
                }
                window.Add(nums[i]);
                if (window.Count > k)
                {
                    window.Remove(nums[i - k]);
                }
            }
            return false;
        }
    }
}
