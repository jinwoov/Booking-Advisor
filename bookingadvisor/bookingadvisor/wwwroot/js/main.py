import requests, os, sys
from bs4 import BeautifulSoup 
from flask import Flask, jsonify, request, render_template

URL = "https://owasp.org/www-project-top-ten/"
r = requests.get(URL) 
soup = BeautifulSoup(r.content, 'html5lib') # If this line causes an error, run 'pip install html5lib' or install html5lib 
# print(soup.prettify()) 

owasp_ten = []

recommendation = soup.find('ol')

for li in recommendation:
    if not '\n' in li:
        owasp_ten.append(li)
    print(sys.argv[0])
