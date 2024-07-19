package a.a.a.service;

import java.util.ArrayList;
import java.util.HashMap;

public interface CommentService {

	public void insertCommentFB(HashMap<String, Object> hm);

	public ArrayList<HashMap<String, Object>> commentListFB(HashMap<String, Object> hm);

	public void deleteComment(HashMap<String, Object> hm);

	public Integer countCommentFB(HashMap<String, Object> hm);


	
	public void insertCommentRB(HashMap<String, Object> hm);

	public ArrayList<HashMap<String, Object>> commentListRB(HashMap<String, Object> hm);

}
