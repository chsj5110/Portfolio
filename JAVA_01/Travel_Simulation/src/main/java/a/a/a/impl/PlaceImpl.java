package a.a.a.impl;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import a.a.a.dao.CommonDAO;
import a.a.a.dao.PlaceDAO;
import a.a.a.service.PlaceService;

@Service("placeService")
public class PlaceImpl implements PlaceService{

	
	@Resource(name = "placeDAO")
	private PlaceDAO placeDAO;
	@Resource(name = "commonDAO")
	private CommonDAO commonDAO;
	//리뷰 미리보기
	@Override
	public boolean insertinfo(HashMap<String, Object> hm) throws SQLException {
		boolean insertplaceinfo = false;
		
		int i = placeDAO.insertinfo(hm);
		if(i != 0 || i == -1) {
			insertplaceinfo = true;
		}
	return insertplaceinfo;	
	}
	@Override
	public int countryCode(HashMap<String, Object> hm) throws SQLException {
		return Integer.parseInt(placeDAO.countryCode(hm).get("CNT").toString());
	}
	@Override
	public ArrayList<HashMap<String, Object>> markerinfo(HashMap<String, Object> hm) throws SQLException {
		return placeDAO.markerinfo(hm);
	}
	
	@Override
	public int recommpname(HashMap<String, Object> hm) throws SQLException {
		return Integer.parseInt(placeDAO.recommpname(hm).get("CNT").toString());
	}
	@Override
	public Object placeimg(HashMap<String, Object> hm) throws SQLException {
		return placeDAO.placeimg(hm);
	}
	
	
	@Override
	public boolean recommchk(HashMap<String, Object> hm) throws SQLException {
		int i = 0;
		try {
			i = Integer.parseInt(placeDAO.recommchk(hm).get("CNT").toString());
			System.out.println("insertrecommchk Impl = "+i);
		} catch (NumberFormatException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		boolean bol = false;

		if (i != 0) {
			bol = true;
		} else {
			bol = false;
		}

		return bol;
	}
	

	@Override
	public boolean insertrecomm(HashMap<String, Object> hm) throws SQLException{
		boolean insertrecomm = false;
		
		int i = 0;
		try {
			i = placeDAO.insertrecomm(hm);
		} catch (Exception e) {
			e.printStackTrace();
		}
		if(i != 0 || i == -1) {
			insertrecomm = true;
		}
	//System.out.println("insertrecomm Impl = "+ i);
	return insertrecomm;	
	}
	
	@Override
	public void recommupdate(HashMap<String, Object> hm) throws SQLException {
		try {
			placeDAO.recommupdate(hm);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	@Override
	public ArrayList<HashMap<String, Object>> mytriplist(HashMap<String, Object> hm) throws SQLException {
		return placeDAO.mytriplist(hm);
	}
	@Override
	public void myTripdel(HashMap<String, Object> hm) throws SQLException {
		placeDAO.myTripdel(hm);
	}
	
	
	//AreaInfo에 여행지 이미지,정보 추가
	@Override
	public void insertAreaInfo(HashMap<String, Object> map) {
		placeDAO.insertAreaInfo(map);
		
	}
	
	//여행지 정보 삭제
	@Override
	public void deletePlaceInfo(HashMap<String, Object> hm) throws SQLException {
		placeDAO.deletePlaceInfo(hm);
		
	}

	
	
		
	
	
	

	

	
}
