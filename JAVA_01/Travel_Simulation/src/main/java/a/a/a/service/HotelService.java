package a.a.a.service;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

public interface HotelService {

	
	public ArrayList<HashMap<String, Object>> selecthotelinfo(HashMap<String, Object> hm) throws SQLException;
	public boolean addhotelinfo(HashMap<String, Object> hm) throws SQLException;
	public boolean modifyhotelinfo(HashMap<String, Object> hm) throws SQLException;
	public boolean deletehotelinfo(HashMap<String, Object> hm) throws SQLException;
	public ArrayList<HashMap<String, Object>> selecthotelinfo2(HashMap<String, Object> hm) throws SQLException;
}
