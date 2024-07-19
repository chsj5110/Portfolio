package a.a.a.dao;

import java.util.ArrayList;
import java.util.HashMap;

import org.springframework.stereotype.Repository;

@Repository("hotelDAO")
public class HotelDAO extends AbstractDAO{

	
	public ArrayList<HashMap<String, Object>> selecthotelinfo(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("hotel.selecthotelinfo", hm);
	}
	
	public int addhotelinfo(HashMap<String, Object> hm){
		
		return (Integer) insert("hotel.addhotelinfo", hm);		
		
	}
	
	public int modifyhotelinfo(HashMap<String, Object> hm){
		
		return (Integer) insert("hotel.modifyhotelinfo", hm);		
		
	}
	
	public int deletehotelinfo(HashMap<String, Object> hm){
		
		return (Integer) insert("hotel.deletehotelinfo", hm);		
		
	}
	
	public ArrayList<HashMap<String, Object>> selecthotelinfo2(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("hotel.selecthotelinfo2", hm);
	}	
	
}
