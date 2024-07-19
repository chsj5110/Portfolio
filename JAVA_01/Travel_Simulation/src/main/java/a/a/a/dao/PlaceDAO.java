package a.a.a.dao;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import org.springframework.stereotype.Repository;

@Repository("placeDAO")
public class PlaceDAO extends AbstractDAO{

	public int insertinfo(HashMap<String, Object> hm) throws SQLException{
		return (Integer) insert("place.insertplaceinfo", hm);
	}

	public HashMap<String, Object> countryCode(HashMap<String, Object> hm) throws SQLException{
		return (HashMap<String, Object>) selectOne("place.countryCodeCNT", hm);
	}
	
	
	//국가코드가 일치하는 여행지 마커들 가져오기
	public ArrayList<HashMap<String, Object>> markerinfo(HashMap<String, Object> hm) throws SQLException{
		return (ArrayList<HashMap<String, Object>>) selectList("place.selectmarkerinfo", hm);
	}
	
	
	public HashMap<String, Object> recommpname(HashMap<String, Object> hm) throws SQLException{
		return (HashMap<String, Object>) selectOne("place.recommpname", hm);
	}
	public Object placeimg(HashMap<String, Object> hm) throws SQLException{
		return (HashMap<String, Object>) selectOne("place.placeimg", hm);
	}
	

	public HashMap<String, Object> recommchk(HashMap<String, Object> hm) throws SQLException{
		return (HashMap<String, Object>) selectOne("place.insertchk", hm);
	}

	public int insertrecomm(HashMap<String, Object> hm) throws SQLException{
		return (Integer) insert("place.insertrecomm", hm);
	}

	public void recommupdate(HashMap<String, Object> hm) throws SQLException{
		update("place.recommupdate", hm);
	}

	public ArrayList<HashMap<String, Object>> mytriplist(HashMap<String, Object> hm) throws SQLException{
		return (ArrayList<HashMap<String, Object>>) selectList("place.mytriplist", hm);
	}

	public void myTripdel(HashMap<String, Object> hm) throws SQLException{
		update("place.myTripdel", hm);
	}

	//AreaInfo에 여행지 이미지,정보 추가
	public void insertAreaInfo(HashMap<String, Object> map) {
		insert("place.insertAreaInfo", map);
		
	}

	public void deletePlaceInfo(HashMap<String, Object> hm) {
		update("place.deletePlaceInfo", hm);
		
	}








}
