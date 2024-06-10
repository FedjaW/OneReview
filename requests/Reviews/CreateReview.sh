#!/bin/bash

HOSTNAME=""
TOKEN=""

curl -X POST $TOKEN \
        -H "AUTHORIZATION: Bearer $TOKEN" \
        -H "Content-Type: application/json" \
        -d '{"Rating": "3", "Text": "Yeah but also meh"}' \
        $HOSTNAME/products/123/reviews
