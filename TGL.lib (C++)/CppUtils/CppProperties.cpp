#include "CppProperties.h"
#include "CppString.h"

namespace CppUtils
{
    CppProperties& CppProperties::operator=(const CppProperties& other)
    {
        Entries.clear();
        for (auto& entry : other.Entries) {
            Entries[entry.first] = entry.second;
        }
        return *this;
    }

    bool CppProperties::operator==(const CppProperties& other)
    {
        if (Entries.size() != other.Entries.size())
            return false;

        return Entries == other.Entries;
    }

    bool CppProperties::operator!=(const CppProperties& other)
    {
        return !operator==(other);
    }

    void CppProperties::Set(std::string name)
    {
        Entries[name] = "";
    }

    void CppProperties::Set(std::string name, std::string value)
    {
        Entries[name] = value;
    }

    void CppProperties::Set(std::string name, int value)
    {
        Entries[name] = String::ToString(value);
    }

    bool CppProperties::Has(std::string name)
    {
        return Entries.find(name) != Entries.end();
    }

    bool CppProperties::Has(std::string name, std::string value)
    {
        for (auto& kv : Entries) {
            if (kv.first == name && kv.second == value) {
                return true;
            }
        }
        return false;
    }

    bool CppProperties::Has(std::string name, int value)
    {
        return Has(name, String::ToString(value));
    }

    std::string CppProperties::GetString(std::string name)
    {
        return Has(name) ? Entries[name] : "";
    }

    int CppProperties::GetNumber(std::string name)
    {
        return Has(name) ? String::ToInt(Entries[name]) : 0;
    }

    void CppProperties::Delete(std::string name)
    {
        Entries.erase(name);
    }

    void CppProperties::DeleteAll()
    {
        Entries.clear();
    }
}
