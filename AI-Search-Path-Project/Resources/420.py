def shortest_path(file = 'test.txt', method = 1):
	class Problem:
		def __init__(self, file):
			
			# read file, init and goal
			nodes = list(open(file).readlines())
			self.size = len(nodes)

			# parse sign and self.h
			sign = list()
			self.dist = dict()
			self.h = dict()
			for i in range(0,self.size):
				node_i = nodes[i] = nodes[i].split()
				sign.append(node_i[0])
				sign_i = node_i[0]
				self.h[sign_i] = int(node_i[1])
				self.dist[sign_i] = node_i[2:]

			# parse self.dist
			for i in range(0,self.size):
				sign_i = sign[i]
				dist_i = self.dist[sign_i]
				self.dist[sign_i] = dict()
				for j in range(0,self.size):
					sign_j = sign[j]
					if sign_j in dist_i:
						ind = dist_i.index(sign_j)
						self.dist[sign_i][sign_j] = float(dist_i[ind+1])
					else:
						self.dist[sign_i][sign_j] = 0.0

			# parse init and goal
			self.init = sign[0]
			self.goal = sign[1]

		def isGoal(self, sig):
			return sig == self.goal

		def children(self, node):
			result =  list()
			lookup = self.dist[node.signature]
			for sign in self.dist:
				dist = lookup[sign]
				if dist != 0:
					result.append(Node(sign, node.g + dist, self.h[sign]))
			return(result)

		def weight(self, source, des):
			return self.dist[source][des]

	class Solution:
		def __init__(self):
			self.process = list()
			self.trace = dict()
			self.success = False
			self.path = 'FAIL'
			self._cost = INFINITY

		def add(self, display_at, content):
			self.process.append((display_at, content))

		def terminate(self,goal,stop):
			self.success = bool(goal)
			self.add('board',('think','Algorithm terminated'))
			if self.success:
				self._cost = 0
				self.path = self.gen_trace(goal,stop)
			self.add('board',('result','Path = '+str(self.path)+'; Cost = '+str(self.cost)))
			return self

		def save(self, child, parent, weight):
			self.trace[child] = [parent, weight]
			self.add('board',('think','Save {} as parent of {}'.format(parent,child)))

		def gen_trace(self, goal, stop):
			if goal == stop:
				return goal
			else:
				self._cost += self.trace[goal][1]
				return self.gen_trace(self.trace[goal][0],stop) + ' -> {}'.format(goal)
		@property
		def cost(self):
			if self._cost == INFINITY:
				return 'INFINITY'
			return self._cost
		

	class Node:
		def __init__(self, signature, g, h):
			self.signature = signature
			self.g = g
			self.h = h
			self.f = g + h

	def BestFS(problem):

		# Pick the node in frontier which minimize h
		def pick():
			best = Node('node',0,0)
			best_i = 0
			min_h = frontier[0].h + 1
			for i in range(0,len(frontier)):
				node_i = frontier[i]
				if node_i.h < min_h:
					best = node_i
					best_i = i
					min_h = node_i.h
			del frontier[best_i]
			sol.add('board',('think','{} currently has the smallest h in frontier'.format(best.signature)))
			return best

		# return the list of signatures of nodes inside a list, optionally adding g
		def signature(l, h = True, join = True):
			r = list()
			for i in range(0,len(l)):
				node = l[i]
				r.append(node.signature+int(h)*(' (h = '+str(node.h)+')'))
			if not join:
				return r
			else:
				return ', '.join(r)

		# BestFS
		sol = Solution()
		node = Node(problem.init, 0, problem.h[problem.init])
		frontier = [node]
		sol.add('board',('think','We start at {}'.format(node.signature)))
		sol.add('map  ',(node.signature,'h = {}'.format(node.h)))
		sol.add('board',('frontier',signature(frontier)))
		explored = []
		sol.add('board',('think','Nothing is explored so far'))
		sol.add('board',('explored',signature(explored)))
		
		while True:
			if (frontier == list()):
				sol.add('board',('think','Empty frontier, cannot proceed'))
				sol.terminate('',problem.init)
				return sol.process

			sol.add('board',('think','Now go on searching by picking a node to explore'))
			parent = node.signature
			node = pick()
			sol.add('board',('think','So, BestFS will now focus on {}'.format(node.signature)))

			if (problem.isGoal(node.signature)):
				sol.add('board',('think','But hey, {} is GOAL'.format(node.signature)))
				sol.add('map  ',(node.signature,'GOAL'))
				sol.terminate(problem.goal,problem.init)
				return sol.process

			explored.append(node)
			sol.add('board',('think','Node {} is moved from frontier to explored'.format(node.signature)))
			sol.add('board',('frontier',signature(frontier)))
			sol.add('board',('explored',signature(explored)))

			# returns nodes with signature and h, and calculated g
			children = problem.children(node)
			sol.add('board',('think','Now look at {} children of {}'.format(len(children),node.signature)))
			for i in range(0,len(children)):
				child = children[i]
				sol.add('board',('think','{}. {}'.format(i + 1,child.signature)))
				set_frontier = set(signature(frontier, False, False))
				set_explored = set(signature(explored, False, False))
				if child.signature not in set.union(set_frontier, set_explored):
					sol.add('board',('think','This node is new, add it to frontier'))
					frontier.append(child)
					sol.add('map  ',(child.signature,'h = {}'.format(child.h)))
					sol.add('board',('frontier',signature(frontier)))
					sol.save(child.signature, node.signature, prob.weight(node.signature, child.signature))
				else:
					sol.add('board',('think','This node is in explored but not frontier, nothing to do with it'))
			sol.add('board',('think','Done looking at all children of {}'.format(node.signature)))

		return sol.process

	def A_star(problem):

		# Pick the node in frontier which minimize g + h
		def pick():
			best = Node('node',0,0)
			best_i = 0
			min_f = frontier[0].f + 1
			for i in range(0,len(frontier)):
				node_i = frontier[i]
				if node_i.f < min_f:
					best = node_i
					best_i = i
					min_f = node_i.f
			del frontier[best_i]
			sol.add('board',('think','{} currently has the smallest f in frontier'.format(best.signature)))
			return best

		# return the list of signatures of nodes inside a list, optionally adding g
		def signature(l, f = True, join = True):
			r = list()
			for i in range(0,len(l)):
				node = l[i]
				r.append(node.signature+int(f)*(' (f = '+str(node.f)+')'))
			if join:
				return ', '.join(r)
			else:
				return r

		# return index of a signature in a list of signatures
		def get_node(l, sig):
			try:
				return(signature(l, False, False).index(sig))
			except:
				return(-1)

		# A star
		sol = Solution()
		node = Node(problem.init, 0, problem.h[problem.init])
		frontier = [node]
		sol.add('board',('think','We start at {}'.format(node.signature)))
		sol.add('map  ',(
						node.signature,'f = {}(g) + {}(h) = {}'.format(
							node.g, node.h, node.f)))
		sol.add('board',('frontier',signature(frontier)))
		explored = []
		sol.add('board',('think','Nothing is explored so far'))
		sol.add('board',('explored',signature(explored)))
		
		while True:
			if (frontier == list()):
				sol.add('board',('think','Empty frontier, cannot proceed'))
				sol.terminate('',problem.init)
				return sol.process

			sol.add('board',('think','Now go on searching by picking a node to explore'))
			parent = node.signature
			node = pick()
			sol.add('board',('think','So, A_star will now focus on {}'.format(node.signature)))

			if (problem.isGoal(node.signature)):
				sol.add('board',('think','But hey, {} is GOAL'.format(node.signature)))
				sol.add('map  ',(node.signature,'GOAL'))
				sol.terminate(problem.goal,problem.init)
				return sol.process

			explored.append(node)
			sol.add('board',('think','Node {} is moved from frontier to explored'.format(node.signature)))
			sol.add('board',('frontier',signature(frontier)))
			sol.add('board',('explored',signature(explored)))

			# returns nodes with signature and h, and calculated g
			children = problem.children(node)
			sol.add('board',('think','Now look at {} children of {}'.format(len(children),node.signature)))
			for i in range(0,len(children)):
				child = children[i]
				sol.add('board',('think','{}. {}'.format(i + 1,child.signature)))
				set_frontier = set(signature(frontier, False, False))
				set_explored = set(signature(explored, False, False))
				if child.signature not in set.union(set_frontier, set_explored):
					sol.add('board',('think','This node is new, add it to frontier'))
					frontier.append(child)
					sol.add('map  ',(
						child.signature,'f = {}(g) + {}(h) = {}'.format(
							child.g, child.h, child.f)))
					sol.add('board',('frontier',signature(frontier)))
					sol.save(child.signature, node.signature, prob.weight(node.signature, child.signature))
				else:
					find = get_node(frontier, child.signature)
					if find > -1 and child.g < frontier[find].g:
						sol.add('board',('think','Found a better path cost to {}, update it'.format(child.signature)))
						frontier[find] = child
						sol.add('map  ',(
							child.signature,'f = {}(g) + {}(h) = {}'.format(
								child.g, child.h, child.f)))
						sol.add('board',('frontier',signature(frontier)))
						sol.save(child.signature, node.signature, prob.weight(node.signature, child.signature))
					else:
						sol.add('board',('think','This node is in explored but not frontier, nothing to do with it'))
			sol.add('board',('think','Done looking at all children of {}'.format(node.signature)))

		return sol.process

	INFINITY = 1e10

	def RBFS(problem):
		
		def RBFS_(problem, node, f_lim):

			def pick():
				best_i = 0
				alt_f = INFINITY
				min_f = INFINITY
				for i in range(0,len(successors)):
					node_i = successors[i]
					if node_i.f < min_f:
						min_f = node_i.f
						best_i = i
				for i in range(0, len(successors)):
					node_i = successors[i]
					if node_i.f == min_f:
						continue
					if node_i.f < alt_f:
						alt_f = node_i.f
				return best_i, alt_f

			states.append((node.signature, f_lim))

			def show(f):
				if f == INFINITY:
					return 'INFINITY'
				return f

			sol.add('board',('think','Now standing at {} with f_lim {}'.format(
				node.signature, show(f_lim))))

			if problem.isGoal(node.signature):
				sol.add('board',('think','But hey, {} is GOAL'.format(node.signature)))
				sol.add('map  ',(node.signature, 'GOAL'))
				sol.terminate(problem.goal,problem.init)
				return 0

			sol.add('board',('think','Expand all successors of {}:'.format(node.signature)))	
			successors = problem.children(node)
			if successors == list():
				sol.add('board',('think',
					'No successor though, unwind from {} with new f = INFINITY'.format(node.signature)))
				return INFINITY

			for i in range(0,len(successors)):
				s_i = successors[i].signature
				s_f = successors[i].f
				successors[i].f = max(s_f, node.f)
				sol.add('board',('think','{}. {}, with new f = max({}.f, {}.f) = max({},{})'.format(
					i+1, s_i, s_i, node.signature, show(s_f), show(node.f))))
				sol.add('map  ',(s_i,'f = {}'.format(show(successors[i].f))))

			while (True):
				best_i, alt_f = pick()
				best = successors[best_i]
				sol.add('board',('think','Among successors of {},'.format(node.signature)))
				sol.add('board',('think','Best node is {} (f = {}), second smallest f is {}'.format(
					best.signature, show(best.f), show(alt_f))))
				sol.save(best.signature, node.signature, prob.weight(node.signature, best.signature))
				if best.f > f_lim:
					sol.add('board',('think','Turn out that all successors of {} exceed f_lim = {}'.format(
						node.signature, show(f_lim))))
					sol.add('board',('think','Unwind from {} with new f = {}'.format(node.signature, best.f)))
					return best.f
				sol.add('board',('think','Move on to {}, with f_lim = min(f_lim,second_best_f) = min({},{})'.format(
					best.signature, show(f_lim), show(alt_f))))
				new_f_lim = min(f_lim, alt_f)
				if (best.signature, new_f_lim) in states:
					sol.add('board',('think','{} with f_lim = {} is already explored, unwind from {}'.format(
						best.signature, show(new_f_lim), node.signature)))
					if node.signature == problem.init:
						sol.terminate('',problem.init)
					return INFINITY
				new_best_f = RBFS_(problem, best, new_f_lim)			
				successors[best_i].f = new_best_f
				if sol.success:
					return new_best_f
				else:
					sol.add('map  ',(best.signature,'f = {}'.format(show(new_best_f))))

		states = list()
		sol = Solution() 
		RBFS_(problem, Node(problem.init, 0, problem.h[problem.init]), INFINITY)
		return sol.process

	prob = Problem(file)
	sol = Solution()
	if (method == 0):
		sol = BestFS(prob)
	else:
		if (method == 1):
			sol = A_star(prob)
		else:
			sol = RBFS(prob)
	return(sol)
