#!/bin/bash

HOSTNAME="http://localhost:5026"
productId="c47ba898-f298-413d-984a-39fe982f16de"

curl -vs -X GET \
        $HOSTNAME/products/$productId
