import http.client
import json
from random import randint

with open('data.json') as data_file:    
    data = json.load(data_file)
for product in data:
    conn = http.client.HTTPSConnection("bug-free-space-trout-xrpp9pqwjq6cprr-5182.app.github.dev")
    payload = json.dumps(product)
    headers = {
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJheyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJnaXZlbl9uYW1lIjoic3RyaW5nIiwibmJmIjoxNzQzNzI1OTczLCJleHAiOjE3NDQzMzA3NzMsImlhdCI6MTc0MzcyNTk3MywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MjQ2IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MjQ2In0.kSzKHgaGenroFH6XDCvdiAk8s_krvu341lvqD4LbMEXZ_mg7SwVHdZFL-P3MhVx6JH9aqtjniprEXVWHQlEQSA'
    }
    conn.request("POST", "/api/products", payload, headers)
    res = conn.getresponse()
    data = res.read()
    print(data.decode("utf-8"))
with open('dataComments.json') as data_file:    
    dataComments = json.load(data_file)
for comment in dataComments:
    productId =str(randint(1,160))
    conn = http.client.HTTPSConnection("bug-free-space-trout-xrpp9pqwjq6cprr-5182.app.github.dev")
    payload = json.dumps(comment)
    headers = {
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJnaXZlbl9uYW1lIjoic3RyaW5nIiwibmJmIjoxNzQzNzI1OTczLCJleHAiOjE3NDQzMzA3NzMsImlhdCI6MTc0MzcyNTk3MywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MjQ2IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MjQ2In0.kSzKHgaGenroFH6XDCvdiAk8s_krvu341lvqD4LbMEXZ_mg7SwVHdZFL-P3MhVx6JH9aqtjniprEXVWHQlEQSA'
    }
    conn.request("POST", "/api/comments/"+productId, payload, headers)
    res = conn.getresponse()
    data = res.read()
    print(data.decode("utf-8"))