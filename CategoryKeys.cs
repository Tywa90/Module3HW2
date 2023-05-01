using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class CategoryKeys
    {
        private string _key;
        private string _alfabetUS = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        private string _keyDigit = "0-9";
        private string _keyOthers = "#";
        private List<User> _userCollection;
        private List<User> _tempList;
        private Dictionary<string, List<User>> _dictionary;

        public CategoryKeys(List<User> collection, Dictionary<string, List<User>> dictionary)
        {
            _userCollection = collection;
            _dictionary = dictionary;
        }

        public void KeysCreat()
        {
            AlfabetKeysUS();
            DigitKeys();
            OtherKeys();
        }

        public void AlfabetKeysUS()
        {
            for (int i = 0; i < _alfabetUS.Length; i++)
            {
                _tempList = new List<User>();
                for (int j = 0; j < _userCollection.Count; j++)
                {
                    _key = _userCollection[j].Name[0].ToString();
                    if (_key.Contains(_alfabetUS[i]))
                    {
                        _tempList.Add(_userCollection[j]);
                    }
                }

                _key = _alfabetUS[i].ToString();
                if (_tempList.Count > 0)
                {
                    _dictionary.Add(_key, _tempList);
                }
            }
        }

        public void DigitKeys()
        {
            _tempList = new List<User>();
            for (int i = 0; i < _userCollection.Count; i++)
            {
                _key = _userCollection[i].Name[0].ToString();
                if (int.TryParse(_key, out int res))
                {
                    _tempList.Add(_userCollection[i]);
                }

                _key = _keyDigit;
            }

            if (_tempList.Count > 0)
            {
                _dictionary.Add(_key, _tempList);
            }
        }

        public void OtherKeys()
        {
            _tempList = new List<User>();

            // something wrong
            var alfabetString = _alfabetUS + "1234567890";
            for (int i = 0; i < _userCollection.Count; i++)
            {
                for (int j = 0; j < alfabetString.Length; j++)
                {
                    _key = _userCollection[i].Name[0].ToString();
                    if (!_key.StartsWith(alfabetString[j].ToString()) && !int.TryParse(_key, out int number))
                    {
                        _tempList.Add(_userCollection[i]);
                    }
                }
            }

            _key = _keyOthers;
            if (_tempList.Count > 0)
            {
                _dictionary.Add(_key, _tempList);
            }
        }
    }
}
