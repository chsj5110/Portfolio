package a.a.a.ctr;

import java.io.File;
import java.security.Principal;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.UUID;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;

import a.a.a.service.BoardService;
import a.a.a.service.ProjectService;
import a.a.a.util.CommonInfo;
import a.a.a.util.PagingVO;

@Controller
public class boardController {
	private ModelAndView ReVRs = new ModelAndView();
	private ModelAndView ReVRs1 = new ModelAndView();
	private ModelAndView look = new ModelAndView();
	private ModelAndView PreV = new ModelAndView();
	private ModelAndView bv = new ModelAndView();
	private ModelAndView mf = new ModelAndView();
	private ModelAndView upmf = new ModelAndView();
	private ModelAndView mv = new ModelAndView();
	private ModelAndView rvlist = new ModelAndView();
	private ModelAndView pinfo = new ModelAndView();
	private ModelAndView doboard = new ModelAndView();
	private ModelAndView rcmp = new ModelAndView();
	private ModelAndView rcmpll = new ModelAndView();
	private ModelAndView spll = new ModelAndView();
	private ModelAndView bmk = new ModelAndView();
	String urlFolder = "\\\\192.168.0.119\\travel_simulator_upload\\";
	
	private static final Logger logger = LoggerFactory.getLogger(boardController.class);
	
	@Resource(name = "boardService")
	private BoardService boardService;
	
	//여행 후기 게시판으로 이동
	@RequestMapping(value = "/board_main.do", method = RequestMethod.GET)
	public ModelAndView home() {
		logger.info("추천게시판 이동");
		mv.setViewName("board/board_main");
		return mv;
	}
	
	@RequestMapping(value = "/board_newRoute.do", method = RequestMethod.GET)
	public ModelAndView board_newRoute() {
		logger.info("추천게시판 이동");
		mv.setViewName("modal/board_newRoute");
		return mv;
	}
	
	
	

	//무한스크롤
	@RequestMapping(value="/infinityLoding.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView infinityLodingRB(@RequestBody HashMap<String, Object> map) throws SQLException {
		
		mv.setViewName("jsonView");
		try {
			logger.info("받은값은 :" +map);
			
			String keyword=(String)map.get("keyword");
			String searchType=(String)map.get("searchType");
			
			PagingVO vo = new PagingVO(0, (int) map.get("nowPage"), (int) map.get("cntPerPage"), keyword, searchType);
			
			int total = boardService.countPRV(vo);
			logger.info("조건을 만족하는 게시글의 수는 "+total);
			
			
			vo = new PagingVO(total, (int) map.get("nowPage"), (int) map.get("cntPerPage"), keyword, searchType);
			logger.info("vo :"+vo);
			mv.addObject("paging", vo);
			mv.addObject("viewAll", boardService.selectPRV(vo));
		} catch(Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		mv.addObject("success", "Y");
		logger.info("mv는"+mv);
		return mv;
	}
	
	
	@RequestMapping(value = "/register.do")
	public String register() {
		return "board/register";
	}
	@RequestMapping(value = "/board.do")
	public ModelAndView boardDo(HttpServletRequest request) {
		
		boolean isAdmin= request.isUserInRole("ROLE_ADMIN");

		String userId= request.getRemoteUser();
		
		doboard.addObject("userId",userId);
		doboard.addObject("isAdmin",isAdmin);
		doboard.setViewName("board/board");
		return doboard;
	}
	@RequestMapping(value = "/modify.do")
	public String modify() {
		return "board/modify";
	}
	
	@RequestMapping(value = "/lookup.do", method = RequestMethod.GET)
	public ModelAndView lookup(String seq,HttpServletRequest request) throws SQLException {
		
		
		boolean isAdmin= request.isUserInRole("ROLE_ADMIN");

		String userId= request.getRemoteUser();
		
		int index = Integer.valueOf(seq);
		boardService.addViews(index);
		

		ReVRs.setViewName("board/lookup");
		ReVRs.addObject("userId",userId);
		ReVRs.addObject("isAdmin",isAdmin);
		ReVRs.addObject("seq", seq);
		return ReVRs;
	}
	
	//리뷰 미리보기
	@RequestMapping(value = "/board/listCnt.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView selectReviewListCnt() throws SQLException{
		PreV.setViewName("jsonView");
		
		PreV.addObject("listCnt", boardService.selectReviewListCnt());
		
		ArrayList<HashMap<String, Object>> Preview = boardService.selectReviewPreview();
		PreV.addObject("Preview", Preview);
		
		logger.info("__________미리보기 리뷰__________");
		logger.info("listCnt,Preview == "+ PreV);
		logger.info("_____________________________");
		return PreV;
	}
	
	
	//리뷰의 썸네일 생성하기
	@PostMapping(value = "/board/insertPreview.json")
	@ResponseBody
	public ModelAndView upload(@RequestParam(value="uploadFile") MultipartFile[] upload,
								@RequestParam(value="previewBno") int previewBno,
								@RequestParam(value="previewID") String previewID,
								@RequestParam(value="previewPlace") String previewPlace,
								@RequestParam(value="previewTag") String previewTag,
								@RequestParam(value="previewImg") String previewImg,
								@RequestParam(value="previewImg1") String previewImg1,
								HttpServletRequest request) throws SQLException {
		
		try {
			
			bv.setViewName("jsonView");
			
			logger.info("update ajax post.....");
	
			String uploadFolder = urlFolder+"PRV_REVIEW";
			String url = "/img/PRV_REVIEW";
			
			logger.info("uploadFolder: "+uploadFolder);
			
			String regDate = "";					
			MultipartFile File = upload[0];
			logger.info("----------------------------");
	
			
			logger.info("-----------------------------");
			logger.info("getToDate = " + CommonInfo.getToDate());
			logger.info("-----------------------------");
			
			//년,월,일 경로 추가하기
			for(int j = 0; j<CommonInfo.getToDate().size();j++) {
				uploadFolder+=("\\"+CommonInfo.getToDate().get(j));
				url+=("\\"+CommonInfo.getToDate().get(j));
				regDate+=CommonInfo.getToDate().get(j)+".";
			}
			
			String uuid = UUID.randomUUID().toString();	
			String uploadFileName = uuid+previewImg; 
			
			
			logger.info("-----------------------------");
			logger.info("uploadFolder =" + uploadFolder);
			logger.info("-----------------------------");
			
			

							
			HashMap<String, Object> hm = new HashMap<String, Object>();
			hm.put("previewBno", previewBno);
			hm.put("previewID", previewID);
			hm.put("previewPlace", previewPlace);
			hm.put("previewTag",  previewTag);
			hm.put("previewImg", uploadFileName);
			hm.put("previewImg1", url+"\\");
			logger.info("입력값은"+hm);
			
			boolean insertChk=boardService.insertPreview(hm);
			
			bv.addObject("insertChk", insertChk);
				
			//파일 저장을 위한 참조변수
			File saveFile = new File(uploadFolder, uploadFileName);
		
			logger.info("dir check start...........");
			
			//경로비교를 위한 참조변수
			File checkPath = new File(uploadFolder.toString());
			
			if(checkPath.isDirectory()==true) {
				((MultipartFile) File).transferTo(saveFile);
				logger.info("디렉토리가 존재합니다.");
			} else {
				//경로에 경로값과 파일이 없다면
				if(!checkPath.exists()) {
					//폴더를 생성
					checkPath.mkdirs();
				}
				((MultipartFile) File).transferTo(saveFile);
				logger.info("디렉토리가 없습니다.");
			}
			logger.info("dir check end..............");
					
			bv.addObject("success","Y");
			
		} catch(Exception e) {
			e.printStackTrace();
			bv.addObject("success","N");
		} // try문 종료			
		
		logger.info("bv는"+bv);
		return bv;
	}

	//리뷰
	@RequestMapping(value = "/board/lookup.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView reviewlookup(@RequestBody HashMap<String, Object> hm) throws SQLException{
		look.setViewName("jsonView");
		look.addObject("reviewlistCnt", boardService.ReviewListCnt(hm));
	
		ArrayList<HashMap<String, Object>> Review = boardService.selectReview(hm);
		look.addObject("Review", Review);
		
		logger.info("___________________________________");
		logger.info("lookup hm ==" + hm);
		logger.info("Review look ==" + look);
		logger.info("___________________________________");
		return look;
	}

	
	//추천 저장된 장소 불러오기
	@RequestMapping(value = "/board/reviewRCMlist.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView reviewRCMlist(@RequestBody HashMap<String, Object> hm) throws SQLException{
		rvlist.setViewName("jsonView");
		ArrayList<HashMap<String, Object>> RCMplace = boardService.reviewRCMlist(hm);
		rvlist.addObject("reviewRCMplace", RCMplace);
		
		logger.info("___________________________________");
		logger.info("userID ==" + hm);
		logger.info("reviewRCMplace ==" + RCMplace);
		logger.info("___________________________________");
		return rvlist;
	}
	
	//추천 on/off 확인
	@RequestMapping(value = "/board/placeinfo.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView placeinfo(@RequestBody HashMap<String, Object> hm) throws SQLException{
		pinfo.setViewName("jsonView");
		
		pinfo.addObject("placeinfo", boardService.placeinfo(hm));
		
		logger.info("___________________________________");
		logger.info("placeName ==" + hm);
		logger.info("placeinfo ==" + pinfo);
		logger.info("___________________________________");
		return pinfo;
	}
	
	//리뷰 글 작성
	@RequestMapping(value = "/board/registerSEQ.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView insertRegisterSEQ() throws SQLException{
		ReVRs.setViewName("jsonView");
		ReVRs.addObject("registerSeq", boardService.insertRegisterSEQ());
		logger.info("___________________________________");
		logger.info("registerSeq ReVRs ==" + ReVRs);
		logger.info("___________________________________");
		return ReVRs;
	}
	
	//리뷰등록 시퀀스 증가
	@RequestMapping(value = "/board/reviewbno.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView reviewSEQ() throws SQLException{
		ReVRs1.setViewName("jsonView");
		ReVRs1.addObject("reviewbno", boardService.reviewSEQ());
		logger.info("___________________________________");
		logger.info("reviewbno ReVRs1 ==" + ReVRs1);
		logger.info("___________________________________");
		return ReVRs1;
	}
	
	//user_review에 저장
	@RequestMapping(value = "/board/register.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView insertRegister(@RequestBody HashMap<String, Object>hm, Principal principal) throws SQLException{
		
		try {
			ReVRs.setViewName("jsonView");
			String user_id = principal.getName();
			hm.put("userId", user_id);
			
			logger.info("___________________________________");
			logger.info("register hm ==" + hm);
			logger.info("___________________________________");
			ReVRs.addObject("insertChk", boardService.insertRegister(hm));
			ReVRs.addObject("success", "Y");
		} catch (Exception e) {
			e.printStackTrace();
			ReVRs.addObject("success", "N");
		}
		return ReVRs;
	}
	
	//수정
	@RequestMapping(value = "/board/modifybno.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView modifyBno(@RequestBody HashMap<String, Object>mfb) throws SQLException{
		mf.setViewName("jsonView");
		HashMap<String, Object> modifyData = boardService.modifydata(mfb);
		mf.addObject("modifydata", modifyData);
		logger.info("___________________________________");
		logger.info("modifyBno mfb ==" + mfb);
		logger.info("modifydata mf ==" + mf);
		logger.info("___________________________________");
		return mf;
	}
	@RequestMapping(value = "/board/modify.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView updatemodify(@RequestBody HashMap<String, Object>upmfb) throws SQLException{
		upmf.setViewName("jsonView");
		upmf.addObject("updateChk", boardService.updatemodify(upmfb));
		logger.info("___________________________________");
		logger.info("updatemodify upmfb ==" + upmfb);
		logger.info("___________________________________");
		return upmf;
	}
	
	
	//게시글 삭제
	@RequestMapping(value = "/deleteRB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView deleteRB(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		logger.info("게시글 삭제중");
		mv.setViewName("jsonView");
		
		try {		
		logger.info("입력값은"+hm);
		
		boardService.deleteRB(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}

	//평점 올리기
		@RequestMapping(value = "/updategrade.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView updategrade(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			//System.out.println("1");
			System.out.println(hm);
			mv.addObject("num ",boardService.updategrade(hm));
			//System.out.println("2");
			//System.out.println("3");
			System.out.println(mv);
			logger.info("hm="+hm);
			logger.info("___________________________________");
			mv.addObject("num " ,boardService.updategrade(hm));
			HashMap<String, Object> avg = boardService.avgGrade(hm);
			hm.put("AVG", avg.get("ROUND"));
			logger.info("grade = " + avg);
			logger.info("___________________________________");
			logger.info("hm = " + hm);
			logger.info("___________________________________");
			logger.info("AVG = " + avg.get("ROUND"));
			logger.info("___________________________________");
			System.out.println("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11111");
			boardService.updateAvg(hm);
			System.out.println("------------+++++++++++++++++---------------");
			
			logger.info("mv = " + mv);
			return mv;
		}
	
	//평점 가져오기
	@RequestMapping(value = "/selectgrade.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView selectgrade(@RequestBody HashMap<String, Object> hm) throws SQLException {
		//System.out.println("0");
		mv.setViewName("jsonView");
		//System.out.println("1");
		ArrayList<HashMap<String, Object>> list = boardService.selectgrade(hm);
		//System.out.println("2");
		mv.addObject("data", list);
		//System.out.println("3");
		System.out.println(mv);
		return mv;
	}
	
	//평점 조회
	@RequestMapping(value = "/viewgrade.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView viewgrade(@RequestBody HashMap<String, Object> hm) throws SQLException {
		//System.out.println("0");
		mv.setViewName("jsonView");
		//System.out.println("1");
		HashMap<String, Object> list = boardService.viewgrade(hm);
		//System.out.println("2");
		mv.addObject("data", list);
		//System.out.println("3");
		System.out.println(mv);
		return mv;
	}
	
	//나의 추천여행리스트 불러오기
	@RequestMapping(value = "/tripList.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView tripList(@RequestBody HashMap<String, Object> hm) throws SQLException {
		//System.out.println("0");
		mv.setViewName("jsonView");
		//System.out.println("1");
		ArrayList<HashMap<String, Object>> list = boardService.tripList(hm);
		//System.out.println("2");
		mv.addObject("data", list);
		//System.out.println("3");
		System.out.println(mv);
		return mv;
	}
	//나의 저장된 여행리스트
	@RequestMapping(value = "/RCMplacelist.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView RCMplacelist(@RequestBody HashMap<String, Object> hm, HttpServletRequest request) throws SQLException {
		rcmp.setViewName("jsonView");
		
		String userId = request.getRemoteUser();
		hm.put("userId", userId);
		ArrayList<HashMap<String, Object>> RCMplacelist = boardService.RCMplacelist(hm);
		rcmp.addObject("RCMplacelist", RCMplacelist );
		System.out.println("RCM_ID===="+hm);
		System.out.println("RCMplacelist===="+rcmp);

		return rcmp;
	}
	
	//나의 저장된 여행리스트 좌표 
	@RequestMapping(value = "/RCMplaceLatLng.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView RCMplaceLatLng(@RequestBody HashMap<String, Object>hm) throws SQLException {
		rcmpll.setViewName("jsonView");
		
		rcmpll.addObject("RCMplaceLatLng", boardService.RCMplaceLatLng(hm));
		System.out.println("RCM_PLACE===="+hm);
		System.out.println("RCMplaceLatLng===="+rcmpll);

		return rcmpll;
	}
	//나의 저장된 여행리스트 선택
	@RequestMapping(value = "/SelectionplaceLatLng.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView SelectionplaceLatLng(@RequestBody HashMap<String, Object>hm, HttpServletRequest request) throws SQLException {
		spll.setViewName("jsonView");
		
		String userId = request.getRemoteUser();
		hm.put("userId", userId);
		System.out.println("MYRCMLIST===="+hm);
		ArrayList<HashMap<String, Object>> myRCMplace = boardService.SelectionplaceLatLng(hm);
		spll.addObject("SelectionplaceLatLng",myRCMplace);
		System.out.println("SelectionplaceLatLng===="+spll);

		return spll;
	}
	// 북마크 가져오기
	@RequestMapping(value = "/bookmarkselect.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView bookmarkselect(@RequestBody HashMap<String, Object>hm, HttpServletRequest request) throws SQLException {
		bmk.setViewName("jsonView");
		
		String userId = request.getRemoteUser();
		hm.put("userId", userId);
		
		System.out.println("bookmarkselect===="+hm);
		ArrayList<HashMap<String, Object>> bookmark = boardService.bookmarkselect(hm);
		bmk.addObject("bookmark",bookmark);
		System.out.println("bookmark===="+bmk);

		return bmk;
	}
	//북마크 정보 가져오기
	@RequestMapping(value = "/bookmarkinfo.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView bookmarkinfo(@RequestBody HashMap<String, Object>hm, HttpServletRequest request) throws SQLException {
		bmk.setViewName("jsonView");
		
		String userId = request.getRemoteUser();
		hm.put("userId", userId);
		
		System.out.println("bookmarkinfo===="+hm);
		ArrayList<HashMap<String, Object>> bookmarkinfo = boardService.bookmarkinfo(hm);
		bmk.addObject("bookmarkinfo",bookmarkinfo);
		System.out.println("bookmarkinfo===="+bmk);

		return bmk;
	}
}

