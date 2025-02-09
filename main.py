from extract import patch_clean
from db import DB, TABLES
from convert import save_to_csv

DATA_FILE = './data/dataRandom.json'

if __name__ == '__main__':
    data_gen = patch_clean(DATA_FILE)
    order_db = DB(TABLES['order'])
    for data in data_gen:
        order_db.post(data)

    for table in TABLES.values():
        db = DB(table)
        data = db.getAll()
        save_to_csv(data, f'./result/{table}.csv')
