#!/bin/bash

HOSTNAME="http://localhost:5026"

curl -vs -X POST \
        -H "Content-Type: application/json" \
        -d '{"Name": "MacBook M3", "Category": "Electronics", "SubCategory": "Laptops"}' \
        $HOSTNAME/products
