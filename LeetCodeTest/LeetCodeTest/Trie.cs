namespace LeetCodeTest
{
    public class Trie
    {
        private class TrieNode
        {
            public TrieNode[] children = new TrieNode[26];
            public bool isEndOfWord = false;
        }

        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        // So‘zni qo‘shish
        public void Insert(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                int index = c - 'a';
                if (node.children[index] == null)
                    node.children[index] = new TrieNode();
                node = node.children[index];
            }
            node.isEndOfWord = true;
        }

        // So‘zni qidirish
        public bool Search(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                int index = c - 'a';
                if (node.children[index] == null)
                    return false;
                node = node.children[index];
            }
            return node.isEndOfWord;
        }

        // Prefiksni tekshirish
        public bool StartsWith(string prefix)
        {
            TrieNode node = root;
            foreach (char c in prefix)
            {
                int index = c - 'a';
                if (node.children[index] == null)
                    return false;
                node = node.children[index];
            }
            return true;
        }

    }

    public class WordDictionary
    {
        private class TrieNode
        {
            public TrieNode[] children = new TrieNode[26];
            public bool isEndOfWord = false;
        }

        private TrieNode root;

        public WordDictionary()
        {
            root = new TrieNode();
        }

        // So‘zni qo‘shish
        public void AddWord(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                int index = c - 'a';
                if (node.children[index] == null)
                    node.children[index] = new TrieNode();
                node = node.children[index];
            }
            node.isEndOfWord = true;
        }

        // So‘zni qidirish ('.' ni ham hisobga oladi)
        public bool Search(string word)
        {
            return Dfs(word, 0, root);
        }

        private bool Dfs(string word, int index, TrieNode node)
        {
            if (index == word.Length)
                return node.isEndOfWord;

            char c = word[index];
            if (c == '.')
            {
                // '.' — barcha farzandlarni tekshiramiz
                foreach (var child in node.children)
                {
                    if (child != null && Dfs(word, index + 1, child))
                        return true;
                }
                return false;
            }
            else
            {
                int idx = c - 'a';
                if (node.children[idx] == null)
                    return false;
                return Dfs(word, index + 1, node.children[idx]);
            }
        }
    }

    public class testWordDic
    {
        HashSet<string> words;
        public testWordDic()
        {
            words = new HashSet<string>();
        }

        public void Add(string word)
        {
            words.Add(word);
        }

        public bool Search(string word)
        {
            bool result = false;
            foreach(var child in words)
            {
                if(child.Length != word.Length) continue;
                int index = word.Length-1;
                while(index>=0)
                {
                    if (word[index]=='.') 
                        { index--; continue; }
                    if (child[index]==word[index]) { index--; continue; }
                    else { index = 1; break; }
                }
                if(index==0)
                    result = true;
            }
            return result;
        }

        
    }

}
