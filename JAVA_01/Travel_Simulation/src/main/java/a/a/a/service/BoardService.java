package a.a.a.service;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import a.a.a.util.PagingVO;

public interface BoardService {
	//리뷰 미리보기
	public int selectReviewListCnt() throws SQLException;
	public ArrayList<HashMap<String, Object>> selectReviewPreview() throws SQLException;
	public boolean insertPreview(HashMap<String, Object> hm) throws SQLException;
	
	//리뷰
	public int ReviewListCnt(HashMap<String, Object> hm) throws SQLException;
	public ArrayList<HashMap<String, Object>>selectReview(HashMap<String, Object> hm) throws SQLException;

	//추천 저장된 장소 불러오기
	public ArrayList<HashMap<String, Object>> reviewRCMlist(HashMap<String, Object> hm)throws SQLException;
	public HashMap<String, Object> placeinfo(HashMap<String, Object> hm)throws SQLException;
	
	//리뷰 글 작성
	public int insertRegisterSEQ() throws SQLException;
	public int reviewSEQ() throws SQLException;
	public boolean insertRegister(HashMap<String, Object> hm) throws SQLException;
	
	//수정
	public HashMap<String, Object> modifydata(HashMap<String, Object> mfb)throws SQLException;
	public boolean updatemodify(HashMap<String, Object> upmfb) throws SQLException;
	
	//평점 올리기 
	public int updategrade(HashMap<String, Object> hm) throws SQLException;
	public HashMap<String, Object> avgGrade(HashMap<String, Object> hm) throws SQLException;
	public int updateAvg(HashMap<String, Object> hm) throws SQLException;
	
	//평점 가져오기
	public ArrayList<HashMap<String, Object>>selectgrade(HashMap<String, Object> hm) throws SQLException;
	//평점 조회
	public HashMap<String, Object> viewgrade(HashMap<String, Object> hm)throws SQLException;
	
	// 게시물 총 갯수
	public int countPRV(PagingVO vo) throws SQLException;

	//페이징 처리하여 게시글 목록 출력
	public ArrayList<HashMap<String,Object>> selectPRV(PagingVO vo) throws SQLException;
	
	public void deleteRB(HashMap<String, Object> hm) throws SQLException;
	
	//나의 추천여행리스트 가져오기
	public ArrayList<HashMap<String, Object>>tripList(HashMap<String, Object> hm) throws SQLException;
	public ArrayList<HashMap<String, Object>> RCMplacelist(HashMap<String, Object> hm) throws SQLException;
	public Object RCMplaceLatLng(HashMap<String, Object> hm)throws SQLException;
	public ArrayList<HashMap<String, Object>> SelectionplaceLatLng(HashMap<String, Object> hm) throws SQLException;
	public ArrayList<HashMap<String, Object>> bookmarkselect(HashMap<String, Object> hm)  throws SQLException;
	public ArrayList<HashMap<String, Object>> bookmarkinfo(HashMap<String, Object> hm) throws SQLException;
	public void addViews(int index) throws SQLException;


}
