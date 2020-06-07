using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace DHG.Helpers
{
    public class CheatCodeScanner : MonoBehaviour
    {

        [System.Serializable]
        public class CheatCodePair
        {
            public string code;
            public UnityEvent onExecute;
        }

        public bool caseSensitive = false;

        public List<CheatCodePair> codes;
        private int maxCodeLength;

        private StringBuilder stringBuilder = new StringBuilder();
        private string buffer;

        void Start()
        {
            if (!caseSensitive)
            {
                foreach (CheatCodePair pair in codes)
                {
                    pair.code = pair.code.ToLowerInvariant();
                    if (pair.code.Length == 0)
                    {
                        Debug.LogError("Zero length code found. Cheat will continually trigger.");
                    }
                }
            }

            maxCodeLength = codes.Select(code => code.code).Max(str => str.Count());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.inputString.Length > 0)
            {
                char[] chars = Input.inputString.ToCharArray();

                foreach(char c in chars)
                {
                    char cVal = caseSensitive ? c : char.ToLowerInvariant(c);
                    stringBuilder.Append(cVal);
                    IEnumerable<CheatCodePair> validCodes = codes.Where(codePair => codePair.code.Last() == cVal);

                    if (validCodes.Any())
                    {
                        string buffer = stringBuilder.ToString();
                        IEnumerable<CheatCodePair> activeCodes = validCodes.Where(codePair => buffer.EndsWith(codePair.code));

                        foreach(CheatCodePair code in activeCodes)
                        {
                            Debug.Log("Code triggered! " + code.code);
                            code.onExecute.Invoke();
                        }
                    }
                }

                if (stringBuilder.Length > maxCodeLength)
                {
                    stringBuilder.Remove(0, stringBuilder.Length - maxCodeLength);
                }

                buffer = stringBuilder.ToString(); // For debug purposes in the Unity Editor
            }

        }
    }
}