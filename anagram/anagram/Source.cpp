/*
 * "caaaat" && "cat"
 * "cat" && ""
 * "" && "" --> I will consider this an anagram. :)
 * "cat" && "cat"
 */
#include<iostream>
#include<string>
#include<unordered_set>

using std::cin;
using std::cout;
using std::endl;
using std::string;
using std::unordered_set;

void swap(string& str, const int& pos1, const int& pos2) {
	char temp = str[pos1];
	str[pos2] = str[pos1];
	str[pos1] = temp;
}

// 3-way partition
void partition(const int& start, const int& end, const int& pivot, string str) {

	int sPivot = pivot;
	int ePivot = pivot;
	// from pivot + 1 to end
	for (size_t i = ePivot + 1; i <= end; i++) {
		if (str[i] < str[ePivot]) {
			swap(str, ePivot + 1, i);
			swap(str, sPivot, ePivot + 1);
			sPivot++;
			ePivot++;
		} else if (str[i] == str[ePivot]) {
			swap(str, ePivot + 1, i);
			ePivot++;
		}
	}

	// from pivot - 1 to start
	for (int i = sPivot - 1; i >= start; i--) {
		if (str[i] > str[sPivot]) {
			swap(str, sPivot - 1, i);
			swap(str, ePivot, sPivot - 1);
			sPivot--;
			ePivot++;
		} else if (str[i] == str[ePivot]) {
			swap(str, sPivot - 1, i);
			sPivot--;
		}
	}
}

void quicksort(const int& start, const int& end, string& str) {
	if (start < end) {
		int pivot = start + ((end - start) / 2);

		partition(start, end, pivot, str);

		quicksort(start, pivot - 1, str);
		quicksort(start, pivot + 1, str);
	}	
}

bool quicksortAreAnagrams(string str1, string str2) {
	int size = str1.length();

	if (size != str2.length()) {
		return false;
	}

	bool result = true;
	quicksort(0, size, str1);
	quicksort(0, size, str2);

	for (size_t i = 0; i < size; i++) {
		if (str1[i] != str2[i]) {
			result = false;
		}
	}

	return result;
}

int main() {
	string string1, string2;
	cin >> string1 >> string2;
	cout << "String is anagram: " << quicksortAreAnagrams(string1, string2) << endl;
}