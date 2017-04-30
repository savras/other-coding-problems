/*
 * "caaaat" && "cat"
 * "cat" && ""
 * "" && "" --> I will consider this an anagram. :)
 * "cat" && "cat"
 */
#include<iostream>
#include<string>
#include<vector>
#include<unordered_set>

using std::cin;
using std::cout;
using std::endl;
using std::string;
using std::vector;
using std::unordered_set;

void swap(vector<char>& arr, const int& pos1, const int& pos2) {
	char temp = arr[pos1];
	arr[pos1] = arr[pos2];
	arr[pos2] = temp;
}

// 3-way partition
void partition(const int& start, const int& end, int& newEnd, int& newStart, string& str) {
	if (start < end) {
		vector<char> arr(str.begin(), str.end());

		int equalPointer = start;
		int lessThanPointer = start;

		swap(arr, start, newEnd);

		for (size_t i = start + 1; i <= end; i++) {
			if (arr[i] < arr[start]) {
				swap(arr, i, lessThanPointer + 1);
				lessThanPointer++;
			}
			else if (arr[i] == arr[start]) {
				swap(arr, equalPointer + 1, i);
				swap(arr, lessThanPointer + 1, i);
				equalPointer++;
				lessThanPointer++;
			}
		}

		// Copy partitioned contents in temp array back to str.
		int counter = start;
		for (size_t i = equalPointer + 1; i <= lessThanPointer; i++) {
			str[counter++] = arr[i];
		}

		newEnd = counter - 1;
		for (size_t i = start; i <= equalPointer; i++) {
			str[counter++] = arr[i];
		}

		newStart = counter;
		for (size_t i = lessThanPointer + 1; i <= end; i++) {
			str[counter++] = arr[i];
		}
	}	
}

void quicksort(const int& start, const int& end, string& str) {
	if (start < end) {
		int newEnd = start + ((end - start) / 2);
		int newStart = newEnd;

		partition(start, end, newEnd, newStart, str);

		quicksort(start, newEnd, str);
		quicksort(newStart, end,  str);
	}	
}

bool quicksortAreAnagrams(string str1, string str2) {
	int size = str1.length();

	if (size != str2.length()) {
		return false;
	}

	bool result = true;
	quicksort(0, size - 1, str1);
	quicksort(0, size - 1, str2);

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
	bool areAnagrams = quicksortAreAnagrams(string1, string2);

	if (areAnagrams) {
		cout << "Strings are anagrams." << endl;
	}
	else {
		cout << "Strings are not anagrams." << endl;
	}
}