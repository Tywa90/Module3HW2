using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class KeysCreate
    {
        private string _key;
        private string _alfabetUS = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        private string _alfabetUA = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЬЮЯ";
        private string _keyDigit = "0-9";
        private List<User> _userCollection;
        private List<User> _tempListUS = new List<User>();
        private List<User> _tempListUA = new List<User>();
        private List<User> _tempListOther = new List<User>();
        private List<User> _tempListDigits = new List<User>();
        private Dictionary<string, List<User>> _dictionary;

        public KeysCreate(List<User> collection, Dictionary<string, List<User>> dictionary)
        {
            _userCollection = collection;
            _dictionary = dictionary;
        }

        public void Creat()
        {
            for (int i = 0; i < _userCollection.Count; i++)
            {
                _key = _userCollection[i].Name[0].ToString();
                for (int j = 0; j < _alfabetUS.Length; j++)
                {
                    if (int.TryParse(_key, out int number))
                    {
                        _tempListDigits.Add(_userCollection[i]);
                        break;
                    }
                    else if (IfAlfabetUS(_key))
                    {
                        _tempListUS.Add(_userCollection[i]);
                        break;
                    }
                    else if (IfAlfabetUA(_key))
                    {
                        _tempListUA.Add(_userCollection[i]);
                        break;
                    }
                    else
                    {
                        _tempListOther.Add(_userCollection[i]);
                        break;
                    }
                }
            }

            if (_tempListUS.Count > 0)
            {
                AlfabetKeysUS(_tempListUS);
            }
            if (_tempListUA.Count > 0)
            {
                AlfabetKeysUA(_tempListUA);
            }

            if (_tempListDigits.Count > 0)
            {
                string keyDigits = "0-9";
                _dictionary.Add(keyDigits, _tempListDigits);
            }

            if (_tempListOther.Count > 0)
            {
                string keyOthers = "#";
                _dictionary.Add(keyOthers, _tempListOther);
            }
        }

        public void AlfabetKeysUS(List<User> users)
        {
            for (int i = 0; i < _alfabetUS.Length; i++)
            {
                List<User> temp = new List<User>();
                for (int j = 0; j < users.Count; j++)
                {
                    _key = users[j].Name[0].ToString();
                    if (_key.Contains(_alfabetUS[i]))
                    {
                        temp.Add(users[j]);
                    }
                }

                _key = _alfabetUS[i].ToString();
                if (temp.Count > 0)
                {
                    _dictionary.Add(_key, temp);
                }
            }
        }
        public void AlfabetKeysUA(List<User> users)
        {
            for (int i = 0; i < _alfabetUA.Length; i++)
            {
                List<User> temp = new List<User>();
                for (int j = 0; j < users.Count; j++)
                {
                    _key = users[j].Name[0].ToString();
                    if (_key.Contains(_alfabetUA[i]))
                    {
                        temp.Add(users[j]);
                    }
                }

                _key = _alfabetUA[i].ToString();
                if (temp.Count > 0)
                {
                    _dictionary.Add(_key, temp);
                }
            }
        }

        public bool IfAlfabetUS(string key)
        {
            for (int i = 0; i < _alfabetUS.Length; i++)
            {
                if (key == _alfabetUS[i].ToString())
                {
                    return true;
                }
            }

            return false;
        }

        public bool IfAlfabetUA(string key)
        {
            for (int i = 0; i < _alfabetUA.Length; i++)
            {
                if (key == _alfabetUA[i].ToString())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
