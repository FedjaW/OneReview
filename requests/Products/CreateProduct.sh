#!/bin/bash

HOSTNAME=""
TOKEN=""

curl -X POST $TOKEN \
        -H "AUTHORIZATION: Bearer $TOKEN" \
        -H "Content-Type: application/json" \
        -d '{"Name": "MacBook M3", "Category": "Electronics", "SubCategory": "Laptops"}' \
        $HOSTNAME/products
