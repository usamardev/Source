using static System.Net.Mime.MediaTypeNames;

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

        public void AddWord(string word)
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
                if(index==-1)
                    result = true;
            }
            return result;
        }

        
    }

    public class SolutionTrie
    {
        private class TrieNode
        {
            public TrieNode[] children = new TrieNode[26];
            public string word = null; // null bo'lmasa — so'z tugagan
        }

        private TrieNode root;
        private int rows, cols;
        private char[][] board;
        private List<string> result = new List<string>();

        public IList<string> FindWords(char[][] board, string[] words)
        {
            this.board = board;
            rows = board.Length;
            cols = board[0].Length;
            root = BuildTrie(words);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Dfs(i, j, root);
                }
            }

            return result;
        }

        private void Dfs(int i, int j, TrieNode node)
        {
            char c = board[i][j];
            if (c == '#' || node.children[c - 'a'] == null) return;

            node = node.children[c - 'a'];
            if (node.word != null)
            {
                result.Add(node.word);
                node.word = null; // duplicate oldini olish uchun
            }

            board[i][j] = '#'; // tashrif belgisi

            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };
            for (int k = 0; k < 4; k++)
            {
                int ni = i + dx[k];
                int nj = j + dy[k];
                if (ni >= 0 && nj >= 0 && ni < rows && nj < cols)
                    Dfs(ni, nj, node);
            }

            board[i][j] = c; // qayta tiklash
        }

        private TrieNode BuildTrie(string[] words)
        {
            TrieNode root = new TrieNode();
            foreach (string word in words)
            {
                TrieNode node = root;
                foreach (char c in word)
                {
                    int index = c - 'a';
                    if (node.children[index] == null)
                        node.children[index] = new TrieNode();
                    node = node.children[index];
                }
                node.word = word;
            }
            return root;
        }
    }


}
