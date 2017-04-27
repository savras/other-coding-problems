#include<iostream>
#include<string>
#include<unordered_set>

using std::cin;
using std::cout;
using std::endl;
using std::string;
using std::unordered_set;

bool isAnagram(string string1, string string2) {
	if (string1.compare(string2) != 0) {
		return false;
	}

	unordered_set<char> set;

	for (size_t i = 0; i < string1.length(); i++) {
		set.insert(string1[i]);
	}

	for (size_t i = 0; i < string2.length(); i++) {
		std::unordered_set<char>::const_iterator got = set.find(string2[i]);

		if (got == set.end()) {
			return false;
		}
	}
	return true;
}

int main() {
	string string1, string2;
	cin >> string1 >> string2;
	cout << "String is anagram: " << isAnagram(string1, string2) << endl;
}