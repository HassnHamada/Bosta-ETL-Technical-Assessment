import requests

ENDPOINT = 'http://localhost:5082'

TABLES = {
    "address": "Address",
    "city": "City",
    "confirm": "Confirm",
    "country": "Country",
    "district": "District",
    "order": "Order",
    "ordertype": "OrderType",
    "payment": "Payment",
    "receiver": "Receiver",
    "star": "Star",
    "zone": "Zone"
}


class DB:
    def __init__(self, table):
        assert table in TABLES.values()
        self._API = f"api/{table}"
        self._NEW_API = f"{self._API}/new"
        self._ALL_API = f"{self._API}/all"

    def post(self, data):
        headers = {
            'accept': '*/*',
            'Content-Type': 'application/json',
        }
        response = requests.post(f'{ENDPOINT}/{self._NEW_API}',
                                 headers=headers, json=data)
        assert response.status_code == requests.codes.created
        return response.json()

    def getAll(self):
        headers = {
            'accept': '*/*',
        }
        response = requests.get(f'{ENDPOINT}/{self._ALL_API}', headers=headers)
        assert response.status_code == requests.codes.ok
        return response.json()

    def get(self, id: int):
        headers = {
            'accept': '*/*',
        }
        response = requests.get(
            f'{ENDPOINT}/{self._API}/{id}', headers=headers)
        assert response.status_code == requests.codes.ok
        return response.json()
