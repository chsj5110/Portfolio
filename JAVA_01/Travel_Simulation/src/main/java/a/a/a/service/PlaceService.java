package a.a.a.service;

import java.sql.SQLException;
import java.util.HashMap;
import java.util.ArrayList;



public interface PlaceService {

	public boolean insertinfo(HashMap<String, Object> hm) throws SQLException;
	public int countryCode(HashMap<String, Object> hm)throws SQLException;
	public ArrayList<HashMap<String, Object>> markerinfo(HashMap<String, Object> hm)throws SQLException;
	public int recommpname(HashMap<String, Object> hm)throws SQLException;
	public Object placeimg(HashMap<String, Object> hm)throws SQLException;
	
	public boolean recommchk(HashMap<String, Object> hm)throws SQLException;
	public boolean insertrecomm(HashMap<String, Object> hm)throws SQLException;
	public void recommupdate(HashMap<String, Object> hm)throws SQLException;
	public ArrayList<HashMap<String, Object>> mytriplist(HashMap<String, Object> hm)throws SQLException;
	public void myTripdel(HashMap<String, Object> hm)throws SQLException;
	
	//Area_Info에 여행지 이미지,정보 추가
	public void insertAreaInfo(HashMap<String, Object> map)throws SQLException;
	
	//여행지 정보 삭제
	public void deletePlaceInfo(HashMap<String, Object> hm)throws SQLException;





}
