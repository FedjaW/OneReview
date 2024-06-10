#!/bin/bash

HOSTNAME=""
TOKEN=""

curl -X GET \
        -H "AUTHORIZATION: Bearer $TOKEN" \
        $HOSTNAME/products/123/reviews
