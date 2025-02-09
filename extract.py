import json
from datetime import datetime
import copy
from datetime import datetime
import re


def convert_date(date_string: str):
    date_string = re.match("(.*)\([\w*\s*]*\)", date_string).group(1).strip()
    dt = datetime.strptime(date_string, "%a %b %d %Y %H:%M:%S GMT%z")
    return dt.isoformat()


def clean(data: dict):
    data = copy.deepcopy(data)

    # Clean up Payment
    data['cod']['amount'] = float(data['cod']['amount'])
    assert data['cod']['isPaidBack'] in ('true', 'false')
    data['cod']['isPaid'] = data['cod']['isPaidBack'] == 'true'
    del data['cod']['isPaidBack']
    data['cod']['paidAmount'] = float(data['cod']['collectedAmount'])
    del data['cod']['collectedAmount']

    # Clean up Confirm
    assert data['confirmation']['isConfirmed'] in ('true', 'false')
    data['confirmation']['isConfirmed'] = data['confirmation']['isConfirmed'] == 'true'
    data['confirmation']['numberOfSmsTrials'] = \
        int(data['confirmation']['numberOfSmsTrials'])

    # Clean up Receiver
    del data['receiver']['_id']

    # Clean up Star
    del data['star']['_id']

    # Clean up City
    del data['dropOffAddress']['city']['_id']
    del data['pickupAddress']['city']['_id']

    # Clean up Country
    del data['dropOffAddress']['country']['_id']
    del data['dropOffAddress']['country']['code']
    del data['pickupAddress']['country']['_id']
    del data['pickupAddress']['country']['code']

    # Clean up District
    data['dropOffAddress']['district'] = {
        'name': data['dropOffAddress']['district']
    }
    data['pickupAddress']['district'] = {
        'name': data['pickupAddress']['district']
    }

    # Clean up Zone
    del data['dropOffAddress']['zone']['_id']
    del data['pickupAddress']['zone']['_id']

    # Clean up Address
    data['dropOffAddress']['floor'] = int(data['dropOffAddress']['floor'])
    data['dropOffAddress']['apartment'] = \
        int(data['dropOffAddress']['apartment'])
    data['dropOffAddress']['latitude'] = \
        float(data['dropOffAddress']['geoLocation'][0])
    data['dropOffAddress']['longitude'] = \
        float(data['dropOffAddress']['geoLocation'][1])
    del data['dropOffAddress']['geoLocation']
    data['pickupAddress']['floor'] = int(data['pickupAddress']['floor'])
    data['pickupAddress']['apartment'] = \
        int(data['pickupAddress']['apartment'])
    data['pickupAddress']['latitude'] = \
        float(data['pickupAddress']['geoLocation'][0])
    data['pickupAddress']['longitude'] = \
        float(data['pickupAddress']['geoLocation'][1])
    del data['pickupAddress']['geoLocation']

    # Clean up Order
    data['collectedFromBusinessDate'] = \
        convert_date(data['collectedFromBusiness']['$date'])
    data['createdAtDate'] = convert_date(data['createdAt']['$date'])
    data['updatedAtDate'] = convert_date(data['updatedAt']['$date'])
    data['tracker'] = data['tracker']['trackerId']
    data['confirm'] = data['confirmation']
    data['type'] = {'type': data['type']}
    del data['collectedFromBusiness']
    del data['createdAt']
    del data['updatedAt']
    del data['_id']
    del data['order_id']
    del data['confirmation']

    return data


def patch_clean(file_path: str):
    with open(file_path, 'r') as file:
        data = json.load(file)
    return (clean(i) for i in data)
