import pickle 
import requests
from bs4 import BeautifulSoup
import json
import tqdm


def get_all_hrefs(url):
	links = list()
	response = requests.get(url)
	soup = BeautifulSoup(response.content, "html.parser")

	for link in soup.find("tbody").find_all("a", {"target": "_blank"}):
		links.append(link.get('href'))

	return links

def get_spell_info_from_page(href):
	def get_spell_json(data):
		json_data = {
			"Level": data[0],
			"CastingTime": data[1],
			"Range": data[2],
			"Components": data[3],
			"Duration": data[4],
			"School": data[5],
			"Description": data[6]
		}
		
		if(len(data) == 11):
			json_data["HigherLevel"] = data[7]
			json_data["Classes"] = data[9]
		else:
			json_data["HigherLevel"] = None
			json_data["Classes"] = data[8]
			
		return json_data

	response = requests.get(href)
	soup = BeautifulSoup(response.content, "html.parser")
	main_div = soup.find("div", "col-md-12")

	strong_data = [text.get_text() for text in main_div.find_all("strong")]
	all_p = [text.get_text().strip() for i, text in enumerate(main_div.find_all("p")) if i != 1]
	spell_data = get_spell_json(strong_data + all_p)
	spell_data["Name"] = main_div.find("span").get_text()
	
	return spell_data

def load_hrefs_from_file():
	return pickle.load(open("spell_hrefs.p", "rb"))

if __name__ == "__main__":
	url = "https://www.dnd-spells.com/spells"
	json_data = list()
	hrefs = get_all_hrefs(url)

	for link in tqdm.tqdm(hrefs):
		json_data.append(get_spell_info_from_page(link))

	with open("spell_data.json", "w+") as outfile:
		json.dump(json_data, outfile)
