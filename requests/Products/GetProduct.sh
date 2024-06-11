#!/bin/bash

HOSTNAME="http://localhost:5026"

curl -vs -X GET \
        $HOSTNAME/products/f2b5cbdf-d140-4e1a-8e52-abca65aa8277
