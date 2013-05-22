using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.IDTables;
using Sitecore.Diagnostics;

namespace Autohaus.Custom.Links
{
    public sealed class ShortUrlTable
    {
        public static IDTableEntry Add(string prefix, string key, ID id)
        {
            Error.AssertString(prefix, "prefix", false);
            Error.AssertString(key, "key", false);
            Error.AssertObject(id, "id");
            return Add(prefix, key, id, ID.Null);
        }

        public static IDTableEntry Add(string prefix, string key, ID id, ID parentID)
        {
            Error.AssertString(prefix, "prefix", false);
            Error.AssertString(key, "key", false);
            Error.AssertObject(id, "id");
            Error.AssertObject(parentID, "parentID");
            return Add(prefix, key, id, parentID, string.Empty);
        }

        public static IDTableEntry Add(string prefix, string key, ID id, ID parentID, string customData)
        {
            Error.AssertString(prefix, "prefix", false);
            Error.AssertString(key, "key", false);
            Error.AssertObject(id, "id");
            Error.AssertObject(parentID, "parentID");
            Error.AssertString(customData, "customData", true);
            IDTableProvider provider = GetProvider();
            var entry = new IDTableEntry(prefix, key, id, parentID, customData);
            provider.Add(entry);
            return entry;
        }

        public static IDTableEntry GetID(string prefix, string key)
        {
            Error.AssertString(prefix, "prefix", false);
            Error.AssertString(key, "key", false);
            return GetProvider().GetID(prefix, key);
        }

        public static IDTableEntry[] GetKeys(string prefix)
        {
            Error.AssertString(prefix, "prefix", false);
            return GetProvider().GetKeys(prefix);
        }

        public static IDTableEntry[] GetKeys(string prefix, ID id)
        {
            Error.AssertString(prefix, "prefix", false);
            Error.AssertObject(id, "id");
            return GetProvider().GetKeys(prefix, id);
        }

        public static IDTableEntry GetNewID(string prefix, string key)
        {
            Error.AssertString(prefix, "prefix", false);
            Error.AssertString(key, "key", false);
            return GetNewID(prefix, key, ID.Null);
        }

        public static IDTableEntry GetNewID(string prefix, string key, ID parentID)
        {
            Error.AssertString(prefix, "prefix", false);
            Error.AssertString(key, "key", false);
            Error.AssertID(parentID, "parentID", true);
            return GetNewID(prefix, key, parentID, string.Empty);
        }

        public static IDTableEntry GetNewID(string prefix, string key, ID parentID, string customData)
        {
            Error.AssertString(prefix, "prefix", false);
            Error.AssertString(key, "key", false);
            Error.AssertID(parentID, "parentID", true);
            Error.AssertString(customData, "customData", true);
            return Add(prefix, key, ID.NewID, parentID, customData);
        }

        private static IDTableProvider GetProvider()
        {
            var iDTable = Factory.CreateObject("ShortUrlTable", true) as IDTableProvider;
            Error.Assert(iDTable != null, "ShortUrlTable not found.");
            return iDTable;
        }

        public static void RemoveID(string prefix, ID id)
        {
            Error.AssertString(prefix, "prefix", false);
            Error.AssertObject(id, "id");
            IDTableProvider provider = GetProvider();
            foreach (IDTableEntry entry in GetKeys(prefix, id))
            {
                provider.Remove(prefix, entry.Key);
            }
        }

        public static void RemoveKey(string prefix, string key)
        {
            Error.AssertString(prefix, "prefix", false);
            Error.AssertString(key, "key", false);
            GetProvider().Remove(prefix, key);
        }
    }
}