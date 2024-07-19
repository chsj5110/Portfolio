package a.a.a.impl;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import a.a.a.dao.HotelDAO;
import a.a.a.service.HotelService;

@Service("hotelService")
public class HotelImpl implements HotelService{
	
	@Resource(name="hotelDAO")
	private HotelDAO hotelDAO;
	
	@Override
	public ArrayList<HashMap<String, Object>> selecthotelinfo(HashMap<String, Object> hm) throws SQLException {
		
		return hotelDAO.selecthotelinfo(hm);
	}
	
	@Override
	public ArrayList<HashMap<String, Object>> selecthotelinfo2(HashMap<String, Object> hm) throws SQLException {
		
		return hotelDAO.selecthotelinfo2(hm);
	}
	
	@Override
	public boolean addhotelinfo(HashMap<String, Object> hm) throws SQLException {
		
		int i = hotelDAO.addhotelinfo(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	
	@Override
	public boolean modifyhotelinfo(HashMap<String, Object> hm) throws SQLException {
		
		int i = hotelDAO.modifyhotelinfo(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	
	@Override
	public boolean deletehotelinfo(HashMap<String, Object> hm) throws SQLException {
		
		int i = hotelDAO.deletehotelinfo(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
}
