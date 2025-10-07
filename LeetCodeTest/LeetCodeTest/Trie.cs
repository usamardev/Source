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
}
