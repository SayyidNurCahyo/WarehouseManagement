-- 1
CREATE TABLE gudang (
    kode UUID PRIMARY KEY,
    nama VARCHAR(100) NOT NULL,
	alamat TEXT NOT NULL
);

CREATE TABLE barang (
    kode UUID PRIMARY KEY,
    nama VARCHAR(100) NOT NULL,
    harga DECIMAL(18, 2) NOT NULL,
    stok INT NOT NULL,
    expired DATE NOT NULL,
    kode_gudang UUID,
    FOREIGN KEY (kode_gudang) REFERENCES gudang(kode)
);


-- 2
CREATE PROCEDURE get_barang_page(page_number INT, rows_page INT) AS $$
DECLARE 
sql TEXT;
BEGIN
    sql :=
    'SELECT 
        g.kode,
        g.nama,
		g.alamat
        b.kode,
        b.nama,
        b.harga,
        b.stok,
        b.expired
    FROM 
        gudang g
    INNER JOIN 
        barang b ON g.kode = b.kode_gudang
    ORDER BY 
        b.kode
    OFFSET (' + CAST(page_number - 1 AS TEXT) + ') * ' 
	+ CAST(rows_page AS TEXT) + 
	' ROWS FETCH NEXT ' + CAST(_p_RowsPerPage AS TEXT) + 
	' ROWS ONLY;';

    EXECUTE sql USING page_number, rows_page;
END;
$$
LANGUAGE plpgsql;


-- 3
CREATE OR REPLACE FUNCTION fungsi_check_expired()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.expired < CURRENT_DATE THEN
        RAISE NOTICE 'Barang % kadaluarsa!', NEW.nama;
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;


CREATE TRIGGER check_expired
  AFTER INSERT
  ON barang
  FOR EACH ROW
  EXECUTE PROCEDURE fungsi_check_expired();